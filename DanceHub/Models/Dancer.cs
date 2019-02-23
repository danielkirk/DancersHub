using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanceHub.Models
{
    [Table("Dancers")]
    public class Dancer
    {
        public int DancerId { get; set; }
        public string Name { get; set; }
        public int DanceExperience { get; set; }

        public ICollection<DanceTeam> DanceTeams { get; set; }
        public ICollection<Achievement> Achievements { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}