namespace DanceHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluentapi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dancers", "AchievementId", "dbo.Achievements");
            DropForeignKey("dbo.Dancers", "DanceTeamId", "dbo.DanceTeams");
            DropIndex("dbo.Dancers", new[] { "DanceTeamId" });
            DropIndex("dbo.Dancers", new[] { "AchievementId" });
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
            
            AddColumn("dbo.DanceTeams", "TeamName", c => c.String());
            DropColumn("dbo.Dancers", "DanceTeamId");
            DropColumn("dbo.Dancers", "AchievementId");
            DropColumn("dbo.DanceTeams", "Team");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DanceTeams", "Team", c => c.String());
            AddColumn("dbo.Dancers", "AchievementId", c => c.Int(nullable: false));
            AddColumn("dbo.Dancers", "DanceTeamId", c => c.Int(nullable: false));
            DropForeignKey("dbo.DancerDanceTeam", "TeamId", "dbo.DanceTeams");
            DropForeignKey("dbo.DancerDanceTeam", "DancerId", "dbo.Dancers");
            DropForeignKey("dbo.DancerAchievements", "AchievementId", "dbo.Achievements");
            DropForeignKey("dbo.DancerAchievements", "DancerId", "dbo.Dancers");
            DropIndex("dbo.DancerDanceTeam", new[] { "TeamId" });
            DropIndex("dbo.DancerDanceTeam", new[] { "DancerId" });
            DropIndex("dbo.DancerAchievements", new[] { "AchievementId" });
            DropIndex("dbo.DancerAchievements", new[] { "DancerId" });
            DropColumn("dbo.DanceTeams", "TeamName");
            DropTable("dbo.DancerDanceTeam");
            DropTable("dbo.DancerAchievements");
            CreateIndex("dbo.Dancers", "AchievementId");
            CreateIndex("dbo.Dancers", "DanceTeamId");
            AddForeignKey("dbo.Dancers", "DanceTeamId", "dbo.DanceTeams", "TeamId", cascadeDelete: true);
            AddForeignKey("dbo.Dancers", "AchievementId", "dbo.Achievements", "AchievementId", cascadeDelete: true);
        }
    }
}
