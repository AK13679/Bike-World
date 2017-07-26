namespace BikeWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Booking : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(),
                        Bike_Id = c.Int(nullable: false),
                        Customer_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bikes", t => t.Bike_Id, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Customer_Id, cascadeDelete: true)
                .Index(t => t.Bike_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Bookings", "Bike_Id", "dbo.Bikes");
            DropIndex("dbo.Bookings", new[] { "Customer_Id" });
            DropIndex("dbo.Bookings", new[] { "Bike_Id" });
            DropTable("dbo.Bookings");
        }
    }
}
