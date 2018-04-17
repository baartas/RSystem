namespace RSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrepareDbModelsForRecrutation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Specializations", "LimitOfPlaces", c => c.Int(nullable: false));
            AddColumn("dbo.Recruits", "AcceptedSpecialization_SpecializationId", c => c.Int());
            CreateIndex("dbo.Recruits", "AcceptedSpecialization_SpecializationId");
            AddForeignKey("dbo.Recruits", "AcceptedSpecialization_SpecializationId", "dbo.Specializations", "SpecializationId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recruits", "AcceptedSpecialization_SpecializationId", "dbo.Specializations");
            DropIndex("dbo.Recruits", new[] { "AcceptedSpecialization_SpecializationId" });
            DropColumn("dbo.Recruits", "AcceptedSpecialization_SpecializationId");
            DropColumn("dbo.Specializations", "LimitOfPlaces");
        }
    }
}
