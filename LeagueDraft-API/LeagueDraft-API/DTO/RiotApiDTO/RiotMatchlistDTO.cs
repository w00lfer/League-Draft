using System.Collections.Generic;

namespace LeagueDraft_API.DTO.RiotApiDTO
{
    public class RiotMatchlistDTO
    {
        public int StartIndex { get; set; }
        public int TotalGames { get; set; }
        public int EndIndex { get; set; }
        public List<RiotMatchReferenceDTO> Matches { get; set; }
    }
}
