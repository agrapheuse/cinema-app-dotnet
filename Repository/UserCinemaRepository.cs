using Contracts;
using Entities.Models;

namespace Repository;

public class UserCinemaRepository : RepositoryBase<UserCinema>, IUserCinemaRepository
{
    public UserCinemaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Cinema> GetUserPreference(Guid userId, bool trackChanges) =>
        FindByCondition(userPref => userPref.UserId == userId, trackChanges)
            .Select(userPref => userPref.Cinema)
            .Where(cinema => cinema != null);

    public void CreateUserPreference(UserCinema userPreference) => Create(userPreference);
}