namespace Information_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addprofileImg : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "InagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "InagePath");
        }
    }
}
