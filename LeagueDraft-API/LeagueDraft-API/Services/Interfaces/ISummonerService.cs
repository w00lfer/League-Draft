using LeagueDraft_API.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeagueDraft_API.Services.Interfaces
{
    public interface ISummonerService
    {
        Task<SummonerWithRankedInfoDTO> GetSummonerByNameAsync(string region, string summonerName);
        Task<List<MatchInfoDTO>> GetMatchesForSummoner(string region, string accountId, int beginIndex, int endIndex);
    }
}