using System.Runtime.Serialization;

namespace DanceHub.Models
{
    [DataContract]
    public class AchievementsDTO
    {
        [DataMember]
        public int AchievementId { get; set; }

        [DataMember]
        public string AchievementName { get; set; }

        [DataMember]
        public int YearsWon { get; set; }
    }
}