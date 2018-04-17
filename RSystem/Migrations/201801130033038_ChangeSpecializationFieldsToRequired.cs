namespace RSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSpecializationFieldsToRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Specializations", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Specializations", "Name", c => c.String());
        }
    }
}
