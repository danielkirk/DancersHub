using System.ComponentModel.DataAnnotations;

namespace DanceHub.Models
{
    public class DanceTeam
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int YearCreated { get; set; }
        public string DirectorName { get; set; }
    }
}