using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public sealed class UserService : IUserService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public UserService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public UserDto CreateUser(UserForCreationDto user)
    {
        var UserEntity = _mapper.Map<User>(user); 
        
        _repository.User.CreateUser(UserEntity);
        _repository.Save(); 
        
        var userToReturn = _mapper.Map<UserDto>(UserEntity); 
        return userToReturn;
    }

    public UserDto GetUserById(Guid id, bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public UserDto GetUserByEmail(string email, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}