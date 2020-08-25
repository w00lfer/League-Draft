using LeagueDraft_API.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeagueDraft_API.Services.Interfaces
{
    public interface ISummonerService
    {
        Task<SummonerInfoDTO> GetSummonerByNameAsync(string region, string summonerName);
        //Task<List<RiotMatchlistDTO>> GetMatchesForSummoner(string accountId);
        Task<List<MatchInfoDTO>> GetMatchesForSummoner(string region, string accountId, int beginIndex, int endIndex);
    }
}