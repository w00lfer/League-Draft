using LeagueDraft_API.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LeagueDraft_API.Services.Interfaces
{
    public interface IChampionService
    {
        Task<List<ChampionInfoDTO>> GetChampionsInfos();
        Task<ChampionInfoDTO> GetChampionInfoByRiotChampionId(int riotChampionId);
    }
}