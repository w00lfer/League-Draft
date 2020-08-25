using AutoMapper;
using LeagueDraft_API.DTO;
using LeagueDraft_API.DTO.RiotApiDTO;
using LeagueDraft_API.Enums;
using LeagueDraft_API.Helpers;
using LeagueDraft_API.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace LeagueDraft_API.Services
{
    public class SummonerService : ISummonerService
    {
        private readonly HttpClient _httpClient;
        private readonly IMapper _mapper;

        public SummonerService(HttpClient httpClient, IMapper mapper)
        {
            _httpClient = httpClient;
            _mapper = mapper;
        }

        public async Task<SummonerInfoDTO> GetSummonerByNameAsync(string region, string summonerName)
        {
            Enum.TryParse(region, out RiotRegionEnum regionEnum);
            var url = RiotApiUrlHelper.GetUrl(regionEnum, "summoner/v4/summoners/by-name", summonerName);

            var riotSummonerDTO = await _httpClient.GetFromJsonAsync<RiotSummonerDTO>(url);
            return _mapper.Map<SummonerInfoDTO>(riotSummonerDTO);

        }

        public async Task<List<MatchInfoDTO>> GetMatchesForSummoner(string region, string accountId, int beginIndex, int endIndex)
        {
            Enum.TryParse(region, out RiotRegionEnum regionEnum);
            var url = RiotApiUrlHelper.GetUrl(regionEnum, "match/v4/matchlists/by-account", accountId,
                new KeyValuePair<string, string>(nameof(beginIndex), beginIndex.ToString()), new KeyValuePair<string, string>(nameof(endIndex), endIndex.ToString()));

            var riotMatchlist = await _httpClient.GetFromJsonAsync<RiotMatchlistDTO>(url);
            
            List<RiotMatchDTO> matches = new List<RiotMatchDTO>();
            var riotMatchTasks = new List<Task<RiotMatchDTO>>();
            foreach (var item in riotMatchlist.Matches)
            {
                riotMatchTasks.Add(_httpClient.GetFromJsonAsync<RiotMatchDTO>(
                    RiotApiUrlHelper.GetUrl(regionEnum, "match/v4/matches", $"{item.GameId}")));
            }
            await Task.WhenAll(riotMatchTasks);
            matches.AddRange(riotMatchTasks.Select(async t => await t).Select(t => t.Result));

            var matchInfoDtos = _mapper.Map<List<RiotMatchDTO>, List<MatchInfoDTO>>(matches, opts => opts.Items["AccountId"] = accountId);
            return matchInfoDtos;
        }
    }
}
