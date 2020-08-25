using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueDraft_API.DTO;
using LeagueDraft_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LeagueDraft_API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChampionController : ControllerBase
    {
        private readonly IChampionService _championService;

        public ChampionController(IChampionService championService)
        {
            _championService = championService;
        }

        [HttpGet]
        public async Task<List<ChampionInfoDTO>> GetAllChampionsInfos() => 
            await _championService.GetChampionsInfos();
    }
}