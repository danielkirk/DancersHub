using System.ComponentModel.DataAnnotations;

namespace DanceHub.Models
{
    public class Achievement
    {
        [Key]
        public int AchievementId { get; set; }
        public string AchievementName { get; set; }
        public int YearsWon { get; set; }
    }
}