namespace Information_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addprofileImg1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "ImagePath", c => c.String());
            DropColumn("dbo.AspNetUsers", "InagePath");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "InagePath", c => c.String());
            DropColumn("dbo.AspNetUsers", "ImagePath");
        }
    }
}
