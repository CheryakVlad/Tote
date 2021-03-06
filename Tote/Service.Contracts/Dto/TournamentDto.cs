﻿

using System.Runtime.Serialization;

namespace Service.Contracts.Dto
{
    [DataContract]
    class TournamentDto
    {
        [DataMember]
        public int TournamentId { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int SportId { get; set; }
    }
}
