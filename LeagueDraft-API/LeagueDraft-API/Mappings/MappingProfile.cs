using System.Collections.Generic;
using AutoMapper;
using LeagueDraft_API.DTO;
using LeagueDraft_API.DTO.RiotApiDTO;
using LeagueDraft_API.Models;
using Microsoft.AspNetCore.Identity;

namespace LeagueDraft_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SignUpUser, IdentityUser>()
                .ForSourceMember(dest => dest.Password, opts => opts.DoNotValidate());
            CreateMap<AddChampionDTO, Champion>();
            CreateMap<Champion, ChampionInfoDTO>();
            CreateMap<RiotSummonerDTO, SummonerInfoDTO>()
                .ForMember(dest => dest.ProfileIconUrl, 
                    opts => opts.MapFrom(src => $"assets/img/ProfileIcons/{src.ProfileIconId}.png"))
                .ForMember(dest => dest.Level, opts => opts.MapFrom(src => src.SummonerLevel));
            CreateMap<RiotLeagueEntryDTO, RankedInfoDTO>()
                .ForMember(dest => dest.QueueType, opts => opts.MapFrom(src => src.QueueType.Replace('_', ' ')))
                .ForMember(dest => dest.TierAndRank, opts => opts.MapFrom(src => $"{src.Tier} {src.Rank}"));
            CreateMap<SummonerInfoDTO, SummonerWithRankedInfoDTO>()
                .ForMember(dest => dest.SummonerInfo, opts => opts.MapFrom(src => src));
            CreateMap<List<RankedInfoDTO>, SummonerWithRankedInfoDTO>()
                .ForMember(dest => dest.RankedInfo, opts => opts.MapFrom(src => src));
            CreateMap<RiotMatchDTO, MatchInfoDTO>()
                .ForMember(dest => dest.Players,
                    opts => opts.MapFrom<MatchInfoPlayersResolver>())
                .ForMember(dest => dest.Won, opts => opts.MapFrom <MatchInfoWonResolver>());
            CreateMap<RiotParticipantStatsDTO, MatchInfoParticipantStatsDTO>();
        }
    }
}
