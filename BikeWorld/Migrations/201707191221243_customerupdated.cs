namespace BikeWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customerupdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "MembershipType_Id", c => c.Byte());
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Customers", "MembershipType_Id");
            AddForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "MembershipType_Id", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipType_Id" });
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.Customers", "MembershipType_Id");
        }
    }
}
