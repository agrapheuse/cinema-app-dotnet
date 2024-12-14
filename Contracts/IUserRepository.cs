using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers(bool trackChanges);
    User GetUserById(Guid id, bool trackChanges);
    User GetUserByEmail(string email, bool trackChanges);
    void CreateUser(User user);
}
