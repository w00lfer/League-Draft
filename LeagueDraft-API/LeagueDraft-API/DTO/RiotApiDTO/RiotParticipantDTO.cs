using System.Collections.Generic;

namespace LeagueDraft_API.DTO.RiotApiDTO
{
    public class RiotParticipantDTO
    {
        public int ParticipantId { get; set; }
        public int ChampionId { get; set; }
        public List<RiotRuneDTO> Runes { get; set; }
        public RiotParticipantStatsDTO Stats { get; set; }
        public int TeamId { get; set; }
        public RiotParticipantTimelineDTO Timeline { get; set; }
        public int Spell1Id { get; set; }
        public int Spell2Id { get; set; }
        public string HighestAchievedSeasonTier { get; set; }
        public List<RiotMasteryDTO> Masteries { get; set; }
    }
}
