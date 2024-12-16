using Entities.Models;

namespace Contracts;

public interface IUserCinemaRepository
{
    IEnumerable<Cinema> GetUserPreference(Guid userId, bool trackChanges);
    void CreateUserPreference(UserCinema userPreference);
}