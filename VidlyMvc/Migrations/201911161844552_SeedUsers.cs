namespace VidlyMvc.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'3695e903-46a3-46d6-a782-61b08ec4af4d', N'guest1@vidly.com', 0, N'ABAo6TOW3vdrZZJn+5OXKv59nj1jUNrZ4MLTfr/w8c+sVefPOl13aeOhalrL6H0H2g==', N'e0b61cae-d83a-45c4-bf47-ded2d78ba252', NULL, 0, 0, NULL, 1, 0, N'guest1@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'999afcb9-251c-4ef8-92ed-5ced37126f4d', N'admin@vidly.com', 0, N'AJLkDwLBLvhbum0+1zZI3vSudwrtvRoRJhjvUSDeyVCB6Cx5zShKG9goc9pNo3FTYw==', N'47c372a2-3252-4fd5-9031-5aff04235c77', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f6a6e339-2585-478d-a666-3aca3c14afec', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'999afcb9-251c-4ef8-92ed-5ced37126f4d', N'f6a6e339-2585-478d-a666-3aca3c14afec')
");
        }

        public override void Down()
        {
        }
    }
}
