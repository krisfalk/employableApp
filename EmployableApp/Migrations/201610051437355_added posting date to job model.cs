namespace EmployableApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedpostingdatetojobmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "PostingDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "PostingDate");
        }
    }
}
