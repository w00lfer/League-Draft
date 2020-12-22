using LeagueDraft_API.DTO.RiotApiDTO;

namespace LeagueDraft_API.DTO
{
    public class MatchInfoParticipantDTO
    {
        public MatchInfoParticipantIdentityDTO Summoner { get; set; }
        public ChampionInfoDTO ChampionInfo { get; set; }
        public MatchInfoParticipantStatsDTO Stats { get; set; }
        public int TeamId { get; set; }
    }
}
