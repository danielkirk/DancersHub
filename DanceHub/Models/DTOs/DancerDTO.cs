using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DanceHub.Models.DTOs
{
    [DataContract]
    public class DancerDTO
    {
        [DataMember]
        public int DancerId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public int DanceExperience { get; set; }

        public List<DanceTeamDTO> DanceTeams { get; set; }
        public List<AchievementDTO> Achievements { get; set; }
    }
}