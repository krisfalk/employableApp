namespace EmployableApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class day3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        StartDate = c.String(),
                        Title = c.String(),
                        Editable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Events", new[] { "UserId" });
            DropTable("dbo.Events");
        }
    }
}
