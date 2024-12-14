using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IUserService
{
    UserDto CreateUser(UserForCreationDto user);
    UserDto GetUserById(Guid id, bool trackChanges);
    UserDto GetUserByEmail(string email, bool trackChanges);
}