using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DanceHub.Models
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

        [DataMember]
        public List<DanceTeamDTO> DanceTeams { get; set; }

        [DataMember]
        public List<AchievementsDTO> Achievements { get; set; }
    }
}