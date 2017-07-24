namespace BikeWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bikedetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bikes", "Name", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bikes", "Name", c => c.String());
        }
    }
}
