namespace DanceHub.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DanceHub.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DanceHub.Models.ApplicationDbContext context)
        {
            context.Dancers.AddOrUpdate(p => p.DancerId,
                new Models.Dancer { Name = "Daniel Kirk", DanceExperience = 2 });
            context.DanceTeams.AddOrUpdate(p => p.TeamId,
                new Models.DanceTeam { TeamName = "ZeroIIHero", DirectorName = "Sean Kirk", YearCreated = 1024 }
                );
            context.Achievements.AddOrUpdate(p => p.AchievementId,
                new Models.Achievement { AchievementName = "SDBDC", YearsWon = 2016 }
                );


            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
