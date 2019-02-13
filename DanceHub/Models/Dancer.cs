using System.ComponentModel.DataAnnotations.Schema;

namespace DanceHub.Models
{
    [Table("Dancers")]
    public class Dancer
    {
        public int DancerId { get; set; }
        public string Name { get; set; }
        public int DanceExperience { get; set; }

        [ForeignKey("DanceTeam")]
        public int DanceTeamId { get; set; }
        public DanceTeam DanceTeam { get; set; }
    }
}