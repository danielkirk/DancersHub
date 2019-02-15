namespace DanceHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sqlprocs : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.DancerAchievement_Insert",
                p => new
                    {
                        DancerId = p.Int(),
                        AchievementId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[DancerAchievements]([DancerId], [AchievementId])
                      VALUES (@DancerId, @AchievementId)"
            );
            
            CreateStoredProcedure(
                "dbo.DancerAchievement_Delete",
                p => new
                    {
                        DancerId = p.Int(),
                        AchievementId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[DancerAchievements]
                      WHERE (([DancerId] = @DancerId) AND ([AchievementId] = @AchievementId))"
            );
            
            CreateStoredProcedure(
                "dbo.DancerDanceTeam_Insert",
                p => new
                    {
                        DancerId = p.Int(),
                        TeamId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[DancerDanceTeam]([DancerId], [TeamId])
                      VALUES (@DancerId, @TeamId)"
            );
            
            CreateStoredProcedure(
                "dbo.DancerDanceTeam_Delete",
                p => new
                    {
                        DancerId = p.Int(),
                        TeamId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[DancerDanceTeam]
                      WHERE (([DancerId] = @DancerId) AND ([TeamId] = @TeamId))"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.DancerDanceTeam_Delete");
            DropStoredProcedure("dbo.DancerDanceTeam_Insert");
            DropStoredProcedure("dbo.DancerAchievement_Delete");
            DropStoredProcedure("dbo.DancerAchievement_Insert");
        }
    }
}
