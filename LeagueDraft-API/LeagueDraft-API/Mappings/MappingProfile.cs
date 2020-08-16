using AutoMapper;
using LeagueDraft_API.DTO;
using LeagueDraft_API.Models;

namespace LeagueDraft_API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddChampionDTO, Champion>();
            CreateMap<Champion, ChampionInfo>();
        }
    }
}
