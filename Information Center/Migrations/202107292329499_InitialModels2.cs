namespace Information_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModels2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            RenameColumn(table: "dbo.Enrollments", name: "CourseId", newName: "Course_Id");
            AlterColumn("dbo.Enrollments", "Course_Id", c => c.Int());
            CreateIndex("dbo.Enrollments", "Course_Id");
            AddForeignKey("dbo.Enrollments", "Course_Id", "dbo.Courses", "Id");
            DropColumn("dbo.Enrollments", "StudentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Enrollments", "StudentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Enrollments", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "Course_Id" });
            AlterColumn("dbo.Enrollments", "Course_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Enrollments", name: "Course_Id", newName: "CourseId");
            CreateIndex("dbo.Enrollments", "CourseId");
            AddForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
    }
}
