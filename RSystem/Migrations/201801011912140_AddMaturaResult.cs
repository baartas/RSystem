namespace RSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaturaResult : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MaturaResults",
                c => new
                    {
                        MaturaResultId = c.Int(nullable: false, identity: true),
                        Points = c.Single(nullable: false),
                        MaturaSubjectId = c.Int(nullable: false),
                        RecruitId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaturaResultId)
                .ForeignKey("dbo.MaturaSubjects", t => t.MaturaSubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Recruits", t => t.RecruitId, cascadeDelete: true)
                .Index(t => t.MaturaSubjectId)
                .Index(t => t.RecruitId);
            
            CreateTable(
                "dbo.MaturaSubjects",
                c => new
                    {
                        MaturaSubjectId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        MaturaType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaturaSubjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MaturaResults", "RecruitId", "dbo.Recruits");
            DropForeignKey("dbo.MaturaResults", "MaturaSubjectId", "dbo.MaturaSubjects");
            DropIndex("dbo.MaturaResults", new[] { "RecruitId" });
            DropIndex("dbo.MaturaResults", new[] { "MaturaSubjectId" });
            DropTable("dbo.MaturaSubjects");
            DropTable("dbo.MaturaResults");
        }
    }
}
