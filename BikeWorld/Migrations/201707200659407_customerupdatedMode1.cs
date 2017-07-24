namespace BikeWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerupdatedMode1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Dob", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "Dob");
        }
    }
}
