using LeagueDraft_API.DTO;
using LeagueDraft_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using System.Linq;

namespace LeagueDraft_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SummonerController : ControllerBase
    {
        private readonly ISummonerService _summonerService;

        public SummonerController(ISummonerService summonerService)
        {
            _summonerService = summonerService;
        }

        [HttpGet]
        [Route("SummonerInfo")]
        public async Task<SummonerWithRankedInfoDTO> GetSummoner(string region, string summonerName)
        {
            var summonerWithRankedInfo = await _summonerService.GetSummonerByNameAsync(region, summonerName);
            return summonerWithRankedInfo;
        }

        [HttpGet]
        [Route("Matches")]
        public async Task<List<MatchInfoDTO>> GetMatchesForSummoner(string region, string accountId, int beginIndex = 0,
            int endIndex = 10)
        {
            var matches = await _summonerService.GetMatchesForSummoner(region, accountId, beginIndex, endIndex);
            var nulle = matches.Select(m => m.Players).Select(p => p.Where(p => p.ChampionInfo.Name == "Seraphine"));
            return matches;
        }
    }
}