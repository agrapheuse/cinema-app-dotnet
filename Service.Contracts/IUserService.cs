using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IUserService
{
    UserDto CreateUser(UserForCreationDto user);
    UserDto GetUserById(Guid id, bool trackChanges);
    UserDto GetUserByEmail(string email, bool trackChanges);
    bool IsMovieLikedByUser(Guid userId, Guid movieId, bool trackChanges);
    LikeDto CreateLike(LikeDto likeDto);

}