using System.Runtime.Serialization;

namespace DanceHub.Models.DTOs
{
    [DataContract]
    public class AchievementDTO
    {
        [DataMember]
        public int AchievementId { get; set; }

        [DataMember]
        public string AchievementName { get; set; }

        [DataMember]
        public int YearsWon { get; set; }
    }
}