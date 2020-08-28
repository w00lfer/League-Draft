using System.Collections.Generic;

namespace LeagueDraft_API.DTO
{
    public class SummonerWithRankedInfoDTO
    {
        public SummonerInfoDTO SummonerInfo { get; set; }
        public List<RankedInfoDTO> RankedInfo { get; set; }
    }
}
