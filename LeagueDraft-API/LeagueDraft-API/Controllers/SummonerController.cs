using LeagueDraft_API.DTO;
using LeagueDraft_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

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
        public async Task<SummonerInfoDTO> GetSummoner(string region, string summonerName)
        {
            var summonerInfo = await _summonerService.GetSummonerByNameAsync(region, summonerName);
            return summonerInfo;
        }

        [HttpGet]
        [Route("Matches")]
        public async Task<List<MatchInfoDTO>> GetMatchesForSummoner(string region, string accountId, int beginIndex = 0,
            int endIndex = 0)
        {
            return await _summonerService.GetMatchesForSummoner(region, accountId, beginIndex, endIndex);
        }
    }
}