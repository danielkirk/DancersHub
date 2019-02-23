using DanceHub.Models;
using System.Data.Entity.ModelConfiguration;

namespace DanceHub
{
    public class DancerEntityConfig : EntityTypeConfiguration<Dancer>
    {
        public DancerEntityConfig()
        {
            this.HasMany(k => k.Achievements)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("DancerId");
                    m.MapRightKey("AchievementId");
                    m.ToTable("DancerAchievements");
                });

            this.HasMany(k => k.DanceTeams)
                    .WithMany()
                    .Map(m =>
                    {
                        m.MapLeftKey("DancerId");
                        m.MapRightKey("TeamId");
                        m.ToTable("DancerDanceTeam");
                    });

            this.HasRequired(s => s.User).WithOptional(m => m.Dancer);

        }

    }
}