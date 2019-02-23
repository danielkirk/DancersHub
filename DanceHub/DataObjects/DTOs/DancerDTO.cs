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

        [DataMember]
        public List<DanceTeamDTO> DanceTeams { get; set; }

        [DataMember]
        public List<AchievementDTO> Achievements { get; set; }

        [DataMember]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}