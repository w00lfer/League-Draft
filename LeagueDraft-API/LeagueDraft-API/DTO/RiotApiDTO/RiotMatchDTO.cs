using System.Collections.Generic;

namespace LeagueDraft_API.DTO.RiotApiDTO
{
    public class RiotMatchDTO
    {
        public long GameId { get; set; }
        public List<RiotParicipantIdentityDTO> ParticipantIdentities { get; set; }
        public int QueueId { get; set; }
        public string GameType { get; set; }
        public long GameDuration { get; set; }
        public List<RiotTeamStatsDTO> Teams { get; set; }
        public string PlatformId { get; set; }
        public long GameCreation { get; set; }
        public int SeasonId { get; set; }
        public string GameVersion { get; set; }
        public int MapId { get; set; }
        public string GameMode { get; set; }
        public List<RiotParticipantDTO> Participants { get; set; }
    }
}
