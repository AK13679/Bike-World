namespace BikeWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aadhaar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Aadhaar", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Aadhaar");
        }
    }
}
