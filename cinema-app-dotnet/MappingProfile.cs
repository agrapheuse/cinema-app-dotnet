using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
namespace cinemaApp;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<Like, LikeDto>();

        CreateMap<UserForCreationDto, User>();
    }
}