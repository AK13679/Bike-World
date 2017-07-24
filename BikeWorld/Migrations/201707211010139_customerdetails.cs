namespace BikeWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerdetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "email", c => c.String(nullable: false, maxLength: 255));
            AddColumn("dbo.Customers", "mobno", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "mobno");
            DropColumn("dbo.Customers", "email");
        }
    }
}
