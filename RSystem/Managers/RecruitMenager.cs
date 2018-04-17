using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using RSystem.DAL;
using RSystem.Models;

namespace RSystem.Managers
{
    public class RecruitMenager
    { 
        public static Task InitializeRecruitAsync(string id,string email)
        {
            return Task.Run(() =>
            {
                var db = new ApplicationDbContext();
                var recruit = new Recruit()
                {
                    ApplicationUserId = id,
                    RecriutData = new RecruitData()
                    {
                        Email = email
                    },
                    MaturaType = MaturaType.Nowa,
                    DateOfPass = DateTime.Today,
                    MaturaNumber = "",
                    MaturaResults = new List<MaturaResult>()
                };

                foreach (var subject in db.MaturaSubjects)
                {
                    recruit.MaturaResults.Add(new MaturaResult()
                    {
                        Points = 0,
                        MaturaSubject = subject
                    });
                }

                db.Recruits.Add(recruit);

                db.SaveChanges();
            });
        }

        public static Task CalculatePointAsync(int id)
        {
            return Task.Run((() =>
            {
                var db=new ApplicationDbContext();
                var recruit = db.Recruits
                    .Include(r => r.RecruitPreferences.Select(s=>s.Specialization.PointsMultipilers))
                    .Include(m => m.MaturaResults.Select(s => s.MaturaSubject))
                    .FirstOrDefault(i => i.RecruitId == id);

                if (recruit != null)
                {
                    foreach (var preference in recruit.RecruitPreferences)
                    {
                        short points = 0;
                        foreach (var multipiler in preference.Specialization.PointsMultipilers
                        .Where(s=>s.MaturaSubject.MaturaType==recruit.MaturaType))
                        {
                            points += (short)(multipiler.Multipiler *
                                              recruit.MaturaResults
                                                  .First(s => s.MaturaSubject == multipiler.MaturaSubject)
                                                  .Points);
                        }
                        preference.Points = points;
                    }

                    db.Entry(recruit).State = EntityState.Modified;
                    db.SaveChanges();
                }
                                             
            }));
        }

        //Calculate points for only one preference
        public static Task CalculatePointAsync(int id, int specializationId)
        {
            return Task.Run(() =>
            {
                var db = new ApplicationDbContext();
                
                var recruitPreference = db.RecruitPreferences
                    .Include(s => s.Specialization.PointsMultipilers)
                    .Include(r=>r.Recruit.MaturaResults.Select(m=>m.MaturaSubject))
                    .FirstOrDefault(r => r.RecruitId == id && r.SpecializationId == specializationId);

                if (recruitPreference != null)
                {
                    short points = 0;
                    foreach (var multipiler in recruitPreference.Specialization.PointsMultipilers)
                    {
                        points += (short) (multipiler.Multipiler *
                                                recruitPreference.Recruit.MaturaResults
                                               .First(s => s.MaturaSubject == multipiler.MaturaSubject)
                                               .Points);
                    }
                    recruitPreference.Points = points;

                    db.Entry(recruitPreference).State = EntityState.Modified;
                    db.SaveChanges();
                }
            });
        }

        public static void RepairPriorityOrder(int id)
        {
            var db=new ApplicationDbContext();

            var preferences = db.RecruitPreferences
                .Where(r => r.RecruitId == id)
                .OrderBy(p=>p.Priority)
                .ToArray();
   
            if(preferences==null)
                return;

            //First priority must be 1
            int currentPriority = 1;
            
            foreach (var preference in preferences)
            {
                preference.Priority =(short)currentPriority;
                currentPriority++;
            }

            db.SaveChanges();
        }
    }
}