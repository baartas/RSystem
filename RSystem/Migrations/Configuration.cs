using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RSystem.DAL;
using RSystem.Managers;
using RSystem.Models;

namespace RSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RSystem.DAL.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RSystem.DAL.ApplicationDbContext context)
        {
            //Initalize Admin role
            //if (!context.Roles.Any(r => r.Name == "Admin"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "Admin" };

            //    manager.Create(role);
            //}

            ////Add Admin role to db
            //if (!context.Users.Any(u => u.UserName == "11111111111"))
            //{
            //    var store = new UserStore<ApplicationUser>(context);
            //    var manager = new UserManager<ApplicationUser>(store);
            //    var user = new ApplicationUser { UserName = "11111111111" };

            //    manager.Create(user, "Admin123");
            //    manager.AddToRole(user.Id, "Admin");
            //}

            ////Add Recruit role
            //if (!context.Roles.Any(r => r.Name == "Recruit"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "Recruit" };

            //    manager.Create(role);
            //}

            //#region New Matura
            ////New Polish Basic
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "J�zyk Polski - podstawowy",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z j�zyka polskiego na poziomie" +
            //                  " podstawowym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z j�zyka polskiego" +
            //                  " na poziomie podstawowym, wybierz 0)"
            //});

            ////New Polish Extended
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "J�zyk Polski - rozszerzona",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z j�zyka polskiego na poziomie" +
            //                  " rozszerzonym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z j�zyka polskiego" +
            //                  " na poziomie rozszerzonym, wybierz 0)"
            //});

            ////New Foreign language Basic
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "J�zyk obcy - podstawowy",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z j�zyka obcego na poziomie" +
            //                  " podstawowym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z j�zyka obcego" +
            //                  " na poziomie podstawowym, wybierz 0)"
            //});

            ////New Foreign language Extended
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "J�zyk obcy - rozszerzony",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z j�zyka obcego na poziomie" +
            //                  " rozszerzonym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z j�zyka obcego" +
            //                  " na poziomie rozszerzonym, wybierz 0)"
            //});

            ////New Math Basic
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Matematyka - podstawowa",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z matematyki na poziomie" +
            //                  " podstawowym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z matematyki" +
            //                  " na poziomie podstawowym, wybierz 0)"
            //});

            ////New Math Extended
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Matematyka - rozszerzona",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z matematyki na poziomie" +
            //                  " rozszerzonym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z matematyki" +
            //                  " na poziomie rozszerzonym, wybierz 0)"
            //});

            ////New Physic Basic
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Fizyka - podstawowa",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z fizyki na poziomie" +
            //                  " podstawowym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z fizyki" +
            //                  " na poziomie podstawowym, wybierz 0)"
            //});

            ////New Physic Extended
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Fizyka - rozszerzona",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z fizyki na poziomie" +
            //                  " rozszerzonym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z fizyki" +
            //                  " na poziomie rozszerzonym, wybierz 0)"
            //});

            ////New Chamistry Basic
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Chemia - podstawowa",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z chemii na poziomie" +
            //                  " podstawowym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z chemii" +
            //                  " na poziomie podstawowym, wybierz 0)"
            //});

            ////New Physic Extended
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Chemia - rozszerzona",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z chemii na poziomie" +
            //                  " rozszerzonym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z chemii" +
            //                  " na poziomie rozszerzonym, wybierz 0)"
            //});

            ////New Biology Basic
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Biologia - podstawowa",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z biologii na poziomie" +
            //                  " podstawowym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z biologii" +
            //                  " na poziomie podstawowym, wybierz 0)"
            //});

            ////New Bilogy Extended
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Biologia - rozszerzona",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z biologii na poziomie" +
            //                  " rozszerzonym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z biologii" +
            //                  " na poziomie rozszerzonym, wybierz 0)"
            //});

            ////New IT Basic
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Informatyka - podstawowa",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z informatyki na poziomie" +
            //                  " podstawowym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z informatyki" +
            //                  " na poziomie podstawowym, wybierz 0)"
            //});

            ////New IT Extended
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Informatyka - rozszerzona",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z informatyki na poziomie" +
            //                  " rozszerzonym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z informatyki" +
            //                  " na poziomie rozszerzonym, wybierz 0)"
            //});

            ////New History Basic
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Historia - podstawowa",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z historii na poziomie" +
            //                  " podstawowym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z historii" +
            //                  " na poziomie podstawowym, wybierz 0)"
            //});

            ////New History Extended
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Historia - rozszerzona",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z historii na poziomie" +
            //                  " rozszerzonym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z historii" +
            //                  " na poziomie rozszerzonym, wybierz 0)"
            //});

            ////New Geography Basic
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Geografia - podstawowa",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z geografii na poziomie" +
            //                  " podstawowym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z geografii" +
            //                  " na poziomie podstawowym, wybierz 0)"
            //});

            ////New Physic Extended
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Geografia - rozszerzona",
            //    MaturaType = MaturaType.Nowa,
            //    Description = "Wynik pisemnego egzaminu maturalnego z geografii na poziomie" +
            //                  " rozszerzonym (je�eli nie zdawa�e� egzaminu dojrza�o�ci z geografii" +
            //                  " na poziomie rozszerzonym, wybierz 0)"
            //});
            //#endregion

            //#region Old Matura
            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "J�zyk Polski",
            //    MaturaType = MaturaType.Stara,
            //    Description = "Wynik pisemnego egzaminu maturalnego z j�zyka polskiego" +
            //                      " ( je�eli nie zdawa�e� egzaminu dojrza�o�ci z j�zyka polskiego" +
            //                      " , wybierz 0 )"
            //});

            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "J�zyk Obcy",
            //    MaturaType = MaturaType.Stara,
            //    Description = "Wynik pisemnego egzaminu maturalnego z j�zyka obcego" +
            //                  " ( je�eli nie zdawa�e� egzaminu dojrza�o�ci z j�zyka obcego" +
            //                  " , wybierz 0 )"
            //});

            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Matematyka",
            //    MaturaType = MaturaType.Stara,
            //    Description = "Wynik pisemnego egzaminu maturalnego z matematyki" +
            //                  " ( je�eli nie zdawa�e� egzaminu dojrza�o�ci z matematyki" +
            //                  " , wybierz 0 )"
            //});

            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Fizyka",
            //    MaturaType = MaturaType.Stara,
            //    Description = "Wynik pisemnego egzaminu maturalnego z fizyki" +
            //                  " ( je�eli nie zdawa�e� egzaminu dojrza�o�ci z fizyki" +
            //                  " , wybierz 0 )"
            //});

            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Chemia",
            //    MaturaType = MaturaType.Stara,
            //    Description = "Wynik pisemnego egzaminu maturalnego z chemii" +
            //                  " ( je�eli nie zdawa�e� egzaminu dojrza�o�ci z chemii" +
            //                  " , wybierz 0 )"
            //});

            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Informatyka",
            //    MaturaType = MaturaType.Stara,
            //    Description = "Wynik pisemnego egzaminu maturalnego z informatyki" +
            //                  " ( je�eli nie zdawa�e� egzaminu dojrza�o�ci z informatyki" +
            //                  " , wybierz 0 )"
            //});

            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Biologia",
            //    MaturaType = MaturaType.Stara,
            //    Description = "Wynik pisemnego egzaminu maturalnego z biologii" +
            //                  " ( je�eli nie zdawa�e� egzaminu dojrza�o�ci z bilogii" +
            //                  " , wybierz 0 )"
            //});

            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Historia",
            //    MaturaType = MaturaType.Stara,
            //    Description = "Wynik pisemnego egzaminu maturalnego z historii" +
            //                  " ( je�eli nie zdawa�e� egzaminu dojrza�o�ci z historii" +
            //                  " , wybierz 0 )"
            //});

            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Geografia",
            //    MaturaType = MaturaType.Stara,
            //    Description = "Wynik pisemnego egzaminu maturalnego z geografii" +
            //                  " ( je�eli nie zdawa�e� egzaminu dojrza�o�ci z geografii" +
            //                  " , wybierz 0 )"
            //});

            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Historia muzyki",
            //    MaturaType = MaturaType.Stara,
            //    Description = "Wynik pisemnego egzaminu maturalnego z historii muzyki" +
            //                  " ( je�eli nie zdawa�e� egzaminu dojrza�o�ci z historii muzyki" +
            //                  " , wybierz 0 )"
            //});

            //context.MaturaSubjects.Add(new MaturaSubject()
            //{
            //    Name = "Historia sztuki",
            //    MaturaType = MaturaType.Stara,
            //    Description = "Wynik pisemnego egzaminu maturalnego z historii muzyki" +
            //                  " ( je�eli nie zdawa�e� egzaminu dojrza�o�ci z historii sztuki" +
            //                  " , wybierz 0 )"
            //});

            //#endregion

            //#region Faculties

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Anglistyki",
            //    Abbrevation = "WA",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Biologii",
            //    Abbrevation = "WB",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Chemii",
            //    Abbrevation = "WC",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Filologi Polskiej i Klasycznej",
            //    Abbrevation = "WFPiK",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Fizyki",
            //    Abbrevation = "WF",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Historii",
            //    Abbrevation = "WH",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Matematyki i Informatyki",
            //    Abbrevation = "WMI",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Nauk Geograficznych i Geologicznych",
            //    Abbrevation = "WNGiG",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Nauk Politycznych i Dziennikarstwa",
            //    Abbrevation = "WNPiD",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Nauk Spo�ecznych",
            //    Abbrevation = "WNS",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Neofilologii",
            //    Abbrevation = "WN",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Prawa i Administracji",
            //    Abbrevation = "WPiA",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Studi�w Edukacyjnych",
            //    Abbrevation = "WSE",
            //});

            //context.Faculties.Add(new Faculty()
            //{
            //    Name = "Wydzia� Teologiczny",
            //    Abbrevation = "WT",
            //});
            //#endregion
        }
    }
}
