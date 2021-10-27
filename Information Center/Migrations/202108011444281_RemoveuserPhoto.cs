namespace Information_Center.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveuserPhoto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AspNetUsers", "UserPhoto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserPhoto", c => c.Binary());
        }
    }
}
