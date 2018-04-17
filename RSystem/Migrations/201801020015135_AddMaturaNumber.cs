namespace RSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMaturaNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recruits", "MaturaNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recruits", "MaturaNumber");
        }
    }
}
