using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface ICinemaService
{
    IEnumerable<CinemaDto> GetCinemaByCity(string city, bool trackChanges);
    IEnumerable<CinemaDto> GetUserPreference(Guid userId, bool trackChanges);
    UserCinemaDto CreateUserPreference(UserCinemaDto userCinema);
}