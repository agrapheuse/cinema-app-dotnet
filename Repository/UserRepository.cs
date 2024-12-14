using Contracts;
using Entities.Models;

namespace Repository
{
    internal class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
        }

        public IEnumerable<User> GetAllUsers(bool trackChanges)
        {
            throw new NotImplementedException();
        }

        public void CreateUser(User user) => Create(user);
    }
}
