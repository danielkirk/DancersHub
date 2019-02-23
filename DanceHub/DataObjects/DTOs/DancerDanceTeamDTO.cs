using System.Runtime.Serialization;

namespace DanceHub.DataObjects.DTOs
{
    [DataContract]
    public class DancerDanceTeamDTO
    {
        [DataMember]
        public int DancerId { get; set; }

        [DataMember]
        public int DanceTeamId { get; set; }
    }
}