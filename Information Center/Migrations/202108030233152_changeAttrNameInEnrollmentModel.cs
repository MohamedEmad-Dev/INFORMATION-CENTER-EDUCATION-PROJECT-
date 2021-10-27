namespace Information_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAttrNameInEnrollmentModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "Course_Id", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "Course_Id" });
            RenameColumn(table: "dbo.Enrollments", name: "Course_Id", newName: "CourseId");
            RenameColumn(table: "dbo.Enrollments", name: "Student_Id", newName: "StudentId");
            RenameIndex(table: "dbo.Enrollments", name: "IX_Student_Id", newName: "IX_StudentId");
            AlterColumn("dbo.Enrollments", "CourseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Enrollments", "CourseId");
            AddForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            AlterColumn("dbo.Enrollments", "CourseId", c => c.Int());
            RenameIndex(table: "dbo.Enrollments", name: "IX_StudentId", newName: "IX_Student_Id");
            RenameColumn(table: "dbo.Enrollments", name: "StudentId", newName: "Student_Id");
            RenameColumn(table: "dbo.Enrollments", name: "CourseId", newName: "Course_Id");
            CreateIndex("dbo.Enrollments", "Course_Id");
            AddForeignKey("dbo.Enrollments", "Course_Id", "dbo.Courses", "Id");
        }
    }
}
