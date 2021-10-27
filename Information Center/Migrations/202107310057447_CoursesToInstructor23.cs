namespace Information_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CoursesToInstructor23 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Courses", name: "InstructorId", newName: "Instructor_Id");
            RenameIndex(table: "dbo.Courses", name: "IX_InstructorId", newName: "IX_Instructor_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Courses", name: "IX_Instructor_Id", newName: "IX_InstructorId");
            RenameColumn(table: "dbo.Courses", name: "Instructor_Id", newName: "InstructorId");
        }
    }
}
