using System.Collections.Generic;

namespace LeagueDraft_API.DTO.RiotApiDTO
{
    public class RiotParticipantTimelineDTO
    {
        public int ParticipantId { get; set; }
        public Dictionary<string, double> CsDiffPerMinDeltas { get; set; }
        public Dictionary<string, double> DamageTakenPerMinDeltas { get; set; }
        public string Role { get; set; }
        public Dictionary<string, double> DamageTakenDiffPerMinDeltas { get; set; }
        public Dictionary<string, double> XpPerMinDetals { get; set; }
        public Dictionary<string, double> xpDiffPerMinDeltas { get; set; }
        public string Lane { get; set; }
        public Dictionary<string, double> CreepsPerMinDeltas { get; set; }
        public Dictionary<string, double> GoldPerMinDeltas { get; set; }
    }
}
