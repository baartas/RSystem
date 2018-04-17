namespace RSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateOfPass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recruits", "MaturaType", c => c.Int(nullable: false));
            AddColumn("dbo.Recruits", "DateOfPass", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recruits", "DateOfPass");
            DropColumn("dbo.Recruits", "MaturaType");
        }
    }
}
