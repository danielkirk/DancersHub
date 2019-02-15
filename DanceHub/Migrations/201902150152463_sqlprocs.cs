namespace DanceHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sqlprocs : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Dancer_Insert",
                p => new
                    {
                        Name = p.String(),
                        DanceExperience = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Dancers]([Name], [DanceExperience])
                      VALUES (@Name, @DanceExperience)
                      
                      DECLARE @DancerId int
                      SELECT @DancerId = [DancerId]
                      FROM [dbo].[Dancers]
                      WHERE @@ROWCOUNT > 0 AND [DancerId] = scope_identity()
                      
                      SELECT t0.[DancerId]
                      FROM [dbo].[Dancers] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[DancerId] = @DancerId"
            );
            
            CreateStoredProcedure(
                "dbo.Dancer_Update",
                p => new
                    {
                        DancerId = p.Int(),
                        Name = p.String(),
                        DanceExperience = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Dancers]
                      SET [Name] = @Name, [DanceExperience] = @DanceExperience
                      WHERE ([DancerId] = @DancerId)"
            );
            
            CreateStoredProcedure(
                "dbo.Dancer_Delete",
                p => new
                    {
                        DancerId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Dancers]
                      WHERE ([DancerId] = @DancerId)"
            );
            
            CreateStoredProcedure(
                "dbo.Achievement_Insert",
                p => new
                    {
                        AchievementName = p.String(),
                        YearsWon = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Achievements]([AchievementName], [YearsWon])
                      VALUES (@AchievementName, @YearsWon)
                      
                      DECLARE @AchievementId int
                      SELECT @AchievementId = [AchievementId]
                      FROM [dbo].[Achievements]
                      WHERE @@ROWCOUNT > 0 AND [AchievementId] = scope_identity()
                      
                      SELECT t0.[AchievementId]
                      FROM [dbo].[Achievements] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[AchievementId] = @AchievementId"
            );
            
            CreateStoredProcedure(
                "dbo.Achievement_Update",
                p => new
                    {
                        AchievementId = p.Int(),
                        AchievementName = p.String(),
                        YearsWon = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Achievements]
                      SET [AchievementName] = @AchievementName, [YearsWon] = @YearsWon
                      WHERE ([AchievementId] = @AchievementId)"
            );
            
            CreateStoredProcedure(
                "dbo.Achievement_Delete",
                p => new
                    {
                        AchievementId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Achievements]
                      WHERE ([AchievementId] = @AchievementId)"
            );
            
            CreateStoredProcedure(
                "dbo.DanceTeam_Insert",
                p => new
                    {
                        TeamName = p.String(),
                        YearCreated = p.Int(),
                        DirectorName = p.String(),
                    },
                body:
                    @"INSERT [dbo].[DanceTeams]([TeamName], [YearCreated], [DirectorName])
                      VALUES (@TeamName, @YearCreated, @DirectorName)
                      
                      DECLARE @TeamId int
                      SELECT @TeamId = [TeamId]
                      FROM [dbo].[DanceTeams]
                      WHERE @@ROWCOUNT > 0 AND [TeamId] = scope_identity()
                      
                      SELECT t0.[TeamId]
                      FROM [dbo].[DanceTeams] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[TeamId] = @TeamId"
            );
            
            CreateStoredProcedure(
                "dbo.DanceTeam_Update",
                p => new
                    {
                        TeamId = p.Int(),
                        TeamName = p.String(),
                        YearCreated = p.Int(),
                        DirectorName = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[DanceTeams]
                      SET [TeamName] = @TeamName, [YearCreated] = @YearCreated, [DirectorName] = @DirectorName
                      WHERE ([TeamId] = @TeamId)"
            );
            
            CreateStoredProcedure(
                "dbo.DanceTeam_Delete",
                p => new
                    {
                        TeamId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[DanceTeams]
                      WHERE ([TeamId] = @TeamId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.DanceTeam_Delete");
            DropStoredProcedure("dbo.DanceTeam_Update");
            DropStoredProcedure("dbo.DanceTeam_Insert");
            DropStoredProcedure("dbo.Achievement_Delete");
            DropStoredProcedure("dbo.Achievement_Update");
            DropStoredProcedure("dbo.Achievement_Insert");
            DropStoredProcedure("dbo.Dancer_Delete");
            DropStoredProcedure("dbo.Dancer_Update");
            DropStoredProcedure("dbo.Dancer_Insert");
        }
    }
}
