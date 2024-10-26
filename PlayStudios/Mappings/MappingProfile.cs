using AutoMapper;
using PlayStudios.DTOs;
using PlayStudios.Models;

namespace PlayStudios.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GameClub, ClubDto>();
            CreateMap<CreateClubDto, GameClub>();
            CreateMap<Event, EventDto>();
        }
    }
}
