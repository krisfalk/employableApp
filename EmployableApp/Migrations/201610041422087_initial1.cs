namespace EmployableApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        JobId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Title = c.String(),
                        CompanyName = c.String(),
                        AppliedFor = c.Boolean(nullable: false),
                        Favorite = c.Boolean(nullable: false),
                        Posting_Link = c.String(),
                        Latitude = c.Double(nullable: false),
                        Longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.JobId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Resumes",
                c => new
                    {
                        ResumeId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Experience = c.String(),
                        Education = c.String(),
                        Skills = c.String(),
                        References = c.String(),
                    })
                .PrimaryKey(t => t.ResumeId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Jobs", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Resumes", new[] { "UserId" });
            DropIndex("dbo.Jobs", new[] { "UserId" });
            DropTable("dbo.Resumes");
            DropTable("dbo.Jobs");
        }
    }
}
