namespace Information_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialEnrollmentModel2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Enrollments", new[] { "Course_Id1" });
            DropIndex("dbo.Enrollments", new[] { "Student_Id1" });
            DropColumn("dbo.Enrollments", "Course_Id");
            DropColumn("dbo.Enrollments", "Student_Id");
            RenameColumn(table: "dbo.Enrollments", name: "Course_Id1", newName: "Course_Id");
            RenameColumn(table: "dbo.Enrollments", name: "Student_Id1", newName: "Student_Id");
            AlterColumn("dbo.Enrollments", "Student_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Enrollments", "Course_Id", c => c.Int());
            CreateIndex("dbo.Enrollments", "Course_Id");
            CreateIndex("dbo.Enrollments", "Student_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Enrollments", new[] { "Student_Id" });
            DropIndex("dbo.Enrollments", new[] { "Course_Id" });
            AlterColumn("dbo.Enrollments", "Course_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Enrollments", "Student_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Enrollments", name: "Student_Id", newName: "Student_Id1");
            RenameColumn(table: "dbo.Enrollments", name: "Course_Id", newName: "Course_Id1");
            AddColumn("dbo.Enrollments", "Student_Id", c => c.Int(nullable: false));
            AddColumn("dbo.Enrollments", "Course_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Enrollments", "Student_Id1");
            CreateIndex("dbo.Enrollments", "Course_Id1");
        }
    }
}
