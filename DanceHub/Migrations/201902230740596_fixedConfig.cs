namespace DanceHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixedConfig : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Achievements",
                c => new
                    {
                        AchievementId = c.Int(nullable: false, identity: true),
                        AchievementName = c.String(),
                        YearsWon = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AchievementId);
            
            CreateTable(
                "dbo.Dancers",
                c => new
                    {
                        DancerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DanceExperience = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.DancerId)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.DanceTeams",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(),
                        YearCreated = c.Int(nullable: false),
                        DirectorName = c.String(),
                    })
                .PrimaryKey(t => t.TeamId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.DancerAchievements",
                c => new
                    {
                        DancerId = c.Int(nullable: false),
                        AchievementId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DancerId, t.AchievementId })
                .ForeignKey("dbo.Dancers", t => t.DancerId, cascadeDelete: true)
                .ForeignKey("dbo.Achievements", t => t.AchievementId, cascadeDelete: true)
                .Index(t => t.DancerId)
                .Index(t => t.AchievementId);
            
            CreateTable(
                "dbo.DancerDanceTeam",
                c => new
                    {
                        DancerId = c.Int(nullable: false),
                        TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DancerId, t.TeamId })
                .ForeignKey("dbo.Dancers", t => t.DancerId, cascadeDelete: true)
                .ForeignKey("dbo.DanceTeams", t => t.TeamId, cascadeDelete: true)
                .Index(t => t.DancerId)
                .Index(t => t.TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Dancers", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DancerDanceTeam", "TeamId", "dbo.DanceTeams");
            DropForeignKey("dbo.DancerDanceTeam", "DancerId", "dbo.Dancers");
            DropForeignKey("dbo.DancerAchievements", "AchievementId", "dbo.Achievements");
            DropForeignKey("dbo.DancerAchievements", "DancerId", "dbo.Dancers");
            DropIndex("dbo.DancerDanceTeam", new[] { "TeamId" });
            DropIndex("dbo.DancerDanceTeam", new[] { "DancerId" });
            DropIndex("dbo.DancerAchievements", new[] { "AchievementId" });
            DropIndex("dbo.DancerAchievements", new[] { "DancerId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Dancers", new[] { "User_Id" });
            DropTable("dbo.DancerDanceTeam");
            DropTable("dbo.DancerAchievements");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.DanceTeams");
            DropTable("dbo.Dancers");
            DropTable("dbo.Achievements");
        }
    }
}
