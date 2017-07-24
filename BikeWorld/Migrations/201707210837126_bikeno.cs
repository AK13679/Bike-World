namespace BikeWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bikeno : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bikes", "NumberInStock", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bikes", "NumberInStock");
        }
    }
}
