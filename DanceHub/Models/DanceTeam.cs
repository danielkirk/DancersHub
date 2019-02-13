using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DanceHub.Models
{
    public class DanceTeam
    {
        [Key, Timestamp]
        public int TeamId { get; set; }
        public string Team { get; set; }
        public int YearCreated { get; set; }
        public string DirectorName { get; set; }

        [InverseProperty("DanceTeam")]
        public ICollection<Dancer> Dancers { get; set; }
    }
}