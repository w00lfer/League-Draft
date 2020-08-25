using AutoMapper;
using LeagueDraft_API.DTO;
using LeagueDraft_API.DTO.RiotApiDTO;
using LeagueDraft_API.Services.Interfaces;
using System.Collections.Generic;

namespace LeagueDraft_API.Mappings
{
    public class MatchInfoPlayersResolver : IValueResolver<RiotMatchDTO, MatchInfoDTO, List<MatchInfoParticipantDTO>>
    {
        private readonly IChampionService _championService;

        public MatchInfoPlayersResolver(IChampionService championService)
        {
            _championService = championService;
        }

        public List<MatchInfoParticipantDTO> Resolve(RiotMatchDTO riotMatchDto, MatchInfoDTO matchInfoDto,
            List<MatchInfoParticipantDTO> matchInfoParticipantDtos, ResolutionContext context)
        {
            matchInfoParticipantDtos = new List<MatchInfoParticipantDTO>();
            var index = 0;
            riotMatchDto.ParticipantIdentities.ForEach(p =>
            {
                matchInfoParticipantDtos.Add(
                    new MatchInfoParticipantDTO
                        {
                            ChampionInfoDto = _championService.GetChampionInfoByRiotChampionId(riotMatchDto.Participants[index].ChampionId).Result,
                            Summoner = new MatchInfoParticipantIdentityDTO {AccountId = p.Player.AccountId, SummonerId = p.Player.SummonerId, SummonerName = p.Player.SummonerName}
                        });
                index++;
            });
            return matchInfoParticipantDtos;
        }
    }
}
