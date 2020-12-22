using System;
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
        private readonly IMapper _mapper;

        public MatchInfoPlayersResolver(IChampionService championService, IMapper mapper)
        {
            _championService = championService;
            _mapper = mapper;
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
                            ChampionInfo = _championService.GetChampionInfoByRiotChampionId(riotMatchDto.Participants[index].ChampionId).Result,
                            Summoner = new MatchInfoParticipantIdentityDTO {AccountId = p.Player.AccountId, SummonerId = p.Player.SummonerId, SummonerName = p.Player.SummonerName},
                            TeamId = riotMatchDto.Participants[index].TeamId,
                            Stats = _mapper.Map<RiotParticipantStatsDTO, MatchInfoParticipantStatsDTO>(riotMatchDto.Participants[index].Stats)
                        });
                index++;
            });
            return matchInfoParticipantDtos;
        }
    }
}
