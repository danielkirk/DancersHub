using System.Runtime.Serialization;

namespace DanceHub.Models
{
    [DataContract]
    public class DanceTeamDTO
    {
        [DataMember]
        public int TeamId { get; set; }

        [DataMember]
        public string TeamName { get; set; }

        [DataMember]
        public int YearCreated { get; set; }

        [DataMember]
        public string DirectorName { get; set; }
    }
}