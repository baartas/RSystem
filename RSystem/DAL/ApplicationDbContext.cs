using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using RSystem.Models;

namespace RSystem.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            this.Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }
        
        public DbSet<Recruit> Recruits { get; set; }
        public DbSet<RecruitData> RecruitDatas { get; set; }
        public DbSet<RecruitPreference> RecruitPreferences { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<MaturaSubject> MaturaSubjects { get; set; }
        public DbSet<MaturaResult> MaturaResults { get; set; }
        public DbSet<PointsMultipiler> PointsMultipilers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Recruit>()
                .HasRequired(r => r.RecriutData)
                .WithRequiredPrincipal(r => r.Recruit);

            modelBuilder.Entity<Recruit>()
                .HasRequired(u => u.ApplicationUser);

            modelBuilder.Entity<Specialization>()
                .HasMany(r => r.RecruitPreferences)
                .WithRequired(s => s.Specialization);

            modelBuilder.Entity<Specialization>()
                .HasMany(r => r.AcceptedRecruits)
                .WithOptional(s => s.AcceptedSpecialization);

            modelBuilder.Entity<Recruit>()
                .HasMany(r => r.RecruitPreferences)
                .WithRequired(r => r.Recruit);

            modelBuilder.Entity<Specialization>()
                .HasRequired(s => s.Faculty)
                .WithMany(s => s.Specializations);

            modelBuilder.Entity<Recruit>()
                .HasMany(m => m.MaturaResults)
                .WithRequired(r => r.Recruit);

            modelBuilder.Entity<MaturaResult>()
                .HasRequired(m => m.MaturaSubject);

            modelBuilder.Entity<Specialization>()
                .HasMany(p => p.PointsMultipilers)
                .WithRequired(s => s.Specialization);

            modelBuilder.Entity<PointsMultipiler>()
                .HasRequired(m => m.MaturaSubject);

        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}