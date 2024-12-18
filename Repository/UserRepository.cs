using Contracts;
using Entities.Models;

namespace Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<User> GetAllUsers(bool trackChanges) => FindAll(trackChanges);

    public User GetUserById(Guid id, bool trackChanges) =>
        FindByCondition(user => user.Uuid == id, trackChanges).FirstOrDefault();

    public User GetUserByEmail(string email, bool trackChanges) =>
        FindByCondition(user => user.Email == email, trackChanges).FirstOrDefault();

    public bool IsUser(string email, bool trackChanges)
    {
        var user = FindByCondition(user => user.Email == email, trackChanges).FirstOrDefault();
        return user != null;
    }

    public void CreateUser(User user) => Create(user);
}