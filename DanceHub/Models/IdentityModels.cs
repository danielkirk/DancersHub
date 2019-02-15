using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DanceHub.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DancehubDb", throwIfV1Schema: false)
        {
            Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
        }

        public DbSet<Dancer> Dancers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Dancer>()
                .HasMany(k => k.Achievements)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("DancerId");
                    m.MapRightKey("AchievementId");
                    m.ToTable("DancerAchievements");
                });

            modelBuilder.Entity<Dancer>()
               .HasMany(k => k.DanceTeams)
               .WithMany()
               .Map(m =>
               {
                   m.MapLeftKey("DancerId");
                   m.MapRightKey("TeamId");
                   m.ToTable("DancerDanceTeam");
               });

            modelBuilder.Entity<Dancer>().MapToStoredProcedures();
            modelBuilder.Entity<DanceTeam>().MapToStoredProcedures();
            modelBuilder.Entity<Achievement>().MapToStoredProcedures();
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}