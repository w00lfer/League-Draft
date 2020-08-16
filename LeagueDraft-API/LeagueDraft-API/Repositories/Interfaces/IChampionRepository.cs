using System.Collections.Generic;
using System.Threading.Tasks;
using LeagueDraft_API.Models;

namespace LeagueDraft_API.Repositories.Interfaces
{
    public interface IChampionRepository
    {
        Task<List<Champion>> GetAllChampions();
        Task AddChampion(Champion champion);
    }
}