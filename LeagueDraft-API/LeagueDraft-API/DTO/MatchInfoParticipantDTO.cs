using LeagueDraft_API.DTO.RiotApiDTO;

namespace LeagueDraft_API.DTO
{
    public class MatchInfoParticipantDTO
    {
        public MatchInfoParticipantIdentityDTO Summoner { get; set; }
        public ChampionInfoDTO ChampionInfoDto { get; set; }
    }
}
