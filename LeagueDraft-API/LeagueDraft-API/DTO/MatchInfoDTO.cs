using System.Collections.Generic;

namespace LeagueDraft_API.DTO
{
    public class MatchInfoDTO
    {
        public bool Won { get; set; }
        public List<MatchInfoParticipantDTO> Players { get; set; }

    }
}
