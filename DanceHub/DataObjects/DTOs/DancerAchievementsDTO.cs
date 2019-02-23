using System.Runtime.Serialization;

namespace DanceHub.DataObjects.DTOs
{
    [DataContract]
    public class DancerAchievementsDTO
    {
        [DataMember]
        public int DancerId { get; set; }

        [DataMember]
        public int AchievementId { get; set; }
    }
}