using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
namespace cinemaApp;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<LikeForCreationDto, Like>()
            .ForMember(dest => dest.ShowingId, opt => opt.MapFrom(src => Guid.Parse(src.ShowingId)))
            .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => Guid.Parse(src.UserId)));

        CreateMap<UserForCreationDto, User>();
        CreateMap<UserCinemaDto, UserCinema>();
    }
}