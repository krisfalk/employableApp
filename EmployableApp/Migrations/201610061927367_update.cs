namespace EmployableApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "start", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "end", c => c.DateTime(nullable: false));
            AddColumn("dbo.Events", "allDay", c => c.Boolean(nullable: false));
            DropColumn("dbo.Events", "StartDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "StartDate", c => c.String());
            DropColumn("dbo.Events", "allDay");
            DropColumn("dbo.Events", "end");
            DropColumn("dbo.Events", "start");
        }
    }
}
