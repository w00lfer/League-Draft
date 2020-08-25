using LeagueDraft_API.Models;
using LeagueDraft_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeagueDraft_API.Repositories
{
    public class ChampionRepository : IChampionRepository
    {
        private readonly AppDbContext _appDbContext;

        public ChampionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<Champion>> GetAllChampions() => await _appDbContext.Champions.OrderBy(c => c.Name).ToListAsync();

        public async Task<Champion> GetChampionByRiotChampionId(int riotChampionId) =>
            await _appDbContext.Champions.Where(c => c.RiotId == riotChampionId).FirstOrDefaultAsync();
        public async Task AddChampion(Champion champion)
        {
            await _appDbContext.Champions.AddAsync(champion);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
