namespace BikeWorld.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedusers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6d5ee2be-a3c8-4bcb-957c-93d533747eb5', N'admin@bikeworld.com', 0, N'AA/jWSC2bupwIVhU261jvN/lHjvnPPCdeh3piBVv/iBN7jD2crMDXyS3sv9Q2xmeVg==', N'ab39c803-5f51-46a0-bec7-edfe362e8774', NULL, 0, 0, NULL, 1, 0, N'admin@bikeworld.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'de341324-fa1f-4938-b4bb-85363ffbbeb3', N'guest@bikeworld.com', 0, N'APjMvZX23sThUVxkkEXVodCrGZuR5NyaqFVMCOk8OtJhXqzcq+w99ijKmChrjClWrA==', N'b35bb149-7c93-4d4f-ac46-11eaa0cda1d6', NULL, 0, 0, NULL, 1, 0, N'guest@bikeworld.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'5ab0f24c-011e-4534-a988-db3ee05cdf52', N'CanManageBikes')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'6d5ee2be-a3c8-4bcb-957c-93d533747eb5', N'5ab0f24c-011e-4534-a988-db3ee05cdf52')

 
");
        }
        
        public override void Down()
        {
        }
    }
}
