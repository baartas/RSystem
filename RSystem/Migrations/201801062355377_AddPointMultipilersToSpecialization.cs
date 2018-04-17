namespace RSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPointMultipilersToSpecialization : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PointsMultipilers",
                c => new
                    {
                        PointsMultipilerId = c.Int(nullable: false, identity: true),
                        SpecializationId = c.Int(nullable: false),
                        MaturaSubjectId = c.Int(nullable: false),
                        Multipiler = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.PointsMultipilerId)
                .ForeignKey("dbo.MaturaSubjects", t => t.MaturaSubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Specializations", t => t.SpecializationId, cascadeDelete: true)
                .Index(t => t.SpecializationId)
                .Index(t => t.MaturaSubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PointsMultipilers", "SpecializationId", "dbo.Specializations");
            DropForeignKey("dbo.PointsMultipilers", "MaturaSubjectId", "dbo.MaturaSubjects");
            DropIndex("dbo.PointsMultipilers", new[] { "MaturaSubjectId" });
            DropIndex("dbo.PointsMultipilers", new[] { "SpecializationId" });
            DropTable("dbo.PointsMultipilers");
        }
    }
}
