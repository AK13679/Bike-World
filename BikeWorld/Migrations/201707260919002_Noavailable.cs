namespace BikeWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Noavailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bikes", "NoAvailable", c => c.Int(nullable: false));
            Sql("UPDATE Bikes SET NoAvailable = NumberInStock");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bikes", "NoAvailable");
        }
    }
}
