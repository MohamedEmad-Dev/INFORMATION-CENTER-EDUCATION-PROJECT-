namespace Information_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "Course_Id", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "Student_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Enrollments", new[] { "Course_Id" });
            DropIndex("dbo.Enrollments", new[] { "Student_Id" });
            AddColumn("dbo.Enrollments", "Course_Id1", c => c.Int());
            AddColumn("dbo.Enrollments", "Student_Id1", c => c.String(maxLength: 128));
            AlterColumn("dbo.Enrollments", "Course_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Enrollments", "Student_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Enrollments", "Course_Id1");
            CreateIndex("dbo.Enrollments", "Student_Id1");
            AddForeignKey("dbo.Enrollments", "Course_Id1", "dbo.Courses", "Id");
            AddForeignKey("dbo.Enrollments", "Student_Id1", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "Student_Id1", "dbo.AspNetUsers");
            DropForeignKey("dbo.Enrollments", "Course_Id1", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "Student_Id1" });
            DropIndex("dbo.Enrollments", new[] { "Course_Id1" });
            AlterColumn("dbo.Enrollments", "Student_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Enrollments", "Course_Id", c => c.Int());
            DropColumn("dbo.Enrollments", "Student_Id1");
            DropColumn("dbo.Enrollments", "Course_Id1");
            CreateIndex("dbo.Enrollments", "Student_Id");
            CreateIndex("dbo.Enrollments", "Course_Id");
            AddForeignKey("dbo.Enrollments", "Student_Id", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Enrollments", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
