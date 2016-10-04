namespace EmployableApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changingdatatypesforvariables : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Addresses", "HouseNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Addresses", "HouseNumber", c => c.Int(nullable: false));
        }
    }
}
