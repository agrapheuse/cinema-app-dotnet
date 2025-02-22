using Shared.DataTransferObjects;

namespace Service.Contracts;

public interface IUserService
{
    UserDto CreateUser(UserForCreationDto user);
    UserDto GetUserById(Guid id, bool trackChanges);
    UserDto GetUserByEmail(string email, bool trackChanges);
    bool IsUser(string email, bool trackChanges);
    bool IsMovieLikedByUser(Guid userId, Guid movieId, bool trackChanges);
    LikeForCreationDto CreateLike(LikeForCreationDto likeDto);
    IEnumerable<ShowingDto> getLikesOfUser(Guid userId, bool trackChanges);
}