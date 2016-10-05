namespace EmployableApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatetoresumetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "JobExperienceOne", c => c.String());
            AddColumn("dbo.Resumes", "JobExperienceTwo", c => c.String());
            AddColumn("dbo.Resumes", "JobExperienceThree", c => c.String());
            AddColumn("dbo.Resumes", "HighSchool", c => c.String());
            AddColumn("dbo.Resumes", "College", c => c.String());
            AddColumn("dbo.Resumes", "OtherSchooling", c => c.String());
            AddColumn("dbo.Resumes", "ReferenceOne", c => c.String());
            AddColumn("dbo.Resumes", "ReferenceTwo", c => c.String());
            AddColumn("dbo.Resumes", "ReferenceThree", c => c.String());
            DropColumn("dbo.Resumes", "Experience");
            DropColumn("dbo.Resumes", "Education");
            DropColumn("dbo.Resumes", "References");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Resumes", "References", c => c.String());
            AddColumn("dbo.Resumes", "Education", c => c.String());
            AddColumn("dbo.Resumes", "Experience", c => c.String());
            DropColumn("dbo.Resumes", "ReferenceThree");
            DropColumn("dbo.Resumes", "ReferenceTwo");
            DropColumn("dbo.Resumes", "ReferenceOne");
            DropColumn("dbo.Resumes", "OtherSchooling");
            DropColumn("dbo.Resumes", "College");
            DropColumn("dbo.Resumes", "HighSchool");
            DropColumn("dbo.Resumes", "JobExperienceThree");
            DropColumn("dbo.Resumes", "JobExperienceTwo");
            DropColumn("dbo.Resumes", "JobExperienceOne");
        }
    }
}
