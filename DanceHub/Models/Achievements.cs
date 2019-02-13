using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanceHub.Models
{
    public class Achievements
    {
        [Key]
        public int AchievementId { get; set; }
        public string AchievementName { get; set; }
        public int YearsWon { get; set; }

        [InverseProperty("Achievements")]
        public ICollection<Dancer> Dancers { get; set; }
    }
}