namespace Information_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels221 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "Course_Id1", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "Student_Id1", "dbo.AspNetUsers");
            DropIndex("dbo.Enrollments", new[] { "Course_Id1" });
            DropIndex("dbo.Enrollments", new[] { "Student_Id1" });
            DropColumn("dbo.Enrollments", "Student_Id");
            DropColumn("dbo.Enrollments", "Course_Id");
            DropColumn("dbo.Enrollments", "EnrollDate");
            DropColumn("dbo.Enrollments", "Course_Id1");
            DropColumn("dbo.Enrollments", "Student_Id1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enrollments", "Student_Id1", c => c.String(maxLength: 128));
            AddColumn("dbo.Enrollments", "Course_Id1", c => c.Int());
            AddColumn("dbo.Enrollments", "EnrollDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Enrollments", "Course_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Enrollments", "Student_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Enrollments", "Student_Id1");
            CreateIndex("dbo.Enrollments", "Course_Id1");
            AddForeignKey("dbo.Enrollments", "Student_Id1", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Enrollments", "Course_Id1", "dbo.Courses", "Id");
        }
    }
}
