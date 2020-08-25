using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using LeagueDraft_API.DTO;
using LeagueDraft_API.Models;
using LeagueDraft_API.Repositories.Interfaces;
using LeagueDraft_API.Services.Interfaces;

namespace LeagueDraft_API.Services
{
    public class ChampionService : IChampionService
    {
        private readonly IChampionRepository _championRepository;
        private readonly IMapper _mapper;

        public ChampionService(IChampionRepository championRepository, IMapper mapper)
        {
            _championRepository = championRepository;
            _mapper = mapper;
        }

        public async Task<List<ChampionInfoDTO>> GetChampionsInfos() =>
            _mapper.Map<List<Champion>, List<ChampionInfoDTO>>(await _championRepository.GetAllChampions());

        public async Task<ChampionInfoDTO> GetChampionInfoByRiotChampionId(int riotChampionId) =>
            _mapper.Map<Champion, ChampionInfoDTO>(await _championRepository.GetChampionByRiotChampionId(riotChampionId));
    }
}
