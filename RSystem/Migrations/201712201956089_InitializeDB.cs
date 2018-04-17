namespace RSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitializeDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        FacultyId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Abbrevation = c.String(),
                    })
                .PrimaryKey(t => t.FacultyId);
            
            CreateTable(
                "dbo.Specializations",
                c => new
                    {
                        SpecializationId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Single(nullable: false),
                        Deadline = c.DateTime(nullable: false),
                        FacultyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SpecializationId)
                .ForeignKey("dbo.Faculties", t => t.FacultyId, cascadeDelete: true)
                .Index(t => t.FacultyId);
            
            CreateTable(
                "dbo.RecruitPreferences",
                c => new
                    {
                        RecruitPreferenceId = c.Int(nullable: false, identity: true),
                        SpecializationId = c.Int(nullable: false),
                        Priority = c.Short(nullable: false),
                        Status = c.Int(nullable: false),
                        Points = c.Short(nullable: false),
                        Paid = c.Boolean(nullable: false),
                        RecruitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecruitPreferenceId)
                .ForeignKey("dbo.Recruits", t => t.RecruitId, cascadeDelete: true)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.SpecializationId)
                .Index(t => t.RecruitId);
            
            CreateTable(
                "dbo.Recruits",
                c => new
                    {
                        RecruitId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RecruitId)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.RecruitDatas",
                c => new
                    {
                        RecruitDataId = c.Int(nullable: false),
                        RecruitId = c.Int(nullable: false),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        LastName = c.String(),
                        Sex = c.Int(nullable: false),
                        Citizenship = c.String(),
                        DocumentType = c.Int(nullable: false),
                        DocumentNumber = c.String(),
                        Street = c.String(),
                        House = c.String(),
                        Flat = c.String(),
                        PostalCode = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        CorespondentAdressSameAsResidence = c.Boolean(nullable: false),
                        CorespondentStreet = c.String(),
                        CorespondentHouse = c.String(),
                        CorespondentFlat = c.String(),
                        CorespondentPostalCode = c.String(),
                        CorespondentCity = c.String(),
                        CorespondentCountry = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        IsDisabled = c.Boolean(nullable: false),
                        FathersName = c.String(),
                        MothersName = c.String(),
                        DayOfBirth = c.DateTime(),
                        BirthCity = c.String(),
                        BirthCountry = c.String(),
                        MilitaryAttitude = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RecruitDataId)
                .ForeignKey("dbo.Recruits", t => t.RecruitDataId)
                .Index(t => t.RecruitDataId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.RecruitPreferences", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.RecruitPreferences", "RecruitId", "dbo.Recruits");
            DropForeignKey("dbo.RecruitDatas", "RecruitDataId", "dbo.Recruits");
            DropForeignKey("dbo.Recruits", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Specializations", "FacultyId", "dbo.Faculties");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.RecruitDatas", new[] { "RecruitDataId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Recruits", new[] { "ApplicationUserId" });
            DropIndex("dbo.RecruitPreferences", new[] { "RecruitId" });
            DropIndex("dbo.RecruitPreferences", new[] { "SpecializationId" });
            DropIndex("dbo.Specializations", new[] { "FacultyId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RecruitDatas");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Recruits");
            DropTable("dbo.RecruitPreferences");
            DropTable("dbo.Specializations");
            DropTable("dbo.Faculties");
        }
    }
}
