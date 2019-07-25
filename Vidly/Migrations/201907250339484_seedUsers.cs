namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'29d931f5-a435-4ed8-980d-51a4b2130952', N'gerardo305@gmail.com', 0, N'AMhte1GBSmE2CrK5pYYU9OqAWVSIzSOPlC9yuep7lGUEFscQCqd5yLYFUEUzDJf9gQ==', N'9c164e91-f4a5-41b6-9ede-d0de04c26d66', NULL, 0, 0, NULL, 1, 0, N'gerardo305@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'94ccb2ef-18d4-46d1-8790-6d2f9eae6e96', N'guest@gmail.com', 0, N'AHe+CYetmd8DuugHrEJwkOph3GVIWahaMgJ8MFuTZCm4wZsKSdyNF80JskoEhkjNng==', N'f207b06a-ee6e-4892-b032-153c25824545', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b1b9625b-6906-453f-9c0c-7d52d84ff2f1', N'admin@gmail.com', 0, N'AMFVzjdrbG56rMa+LKx8XmicSJzx48kEW5ldcmaoBoLu6Dz4n1fJWDP+y34COKdOkQ==', N'b0326dd7-e8c4-4e7c-9b01-614be1e93d12', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
            
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7b2d4275-9f9b-47ae-b3a4-2e4acd2afcee', N'CanManageMovies')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'b1b9625b-6906-453f-9c0c-7d52d84ff2f1', N'7b2d4275-9f9b-47ae-b3a4-2e4acd2afcee')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
