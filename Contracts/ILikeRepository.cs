using Entities.Models;

namespace Contracts;

public interface ILikeRepository
{
    IEnumerable<Showing> GetLikesOfUser(Guid guid, bool trackChanges);
    bool IsMovieLikedByUser(Guid userId, Guid movieId, bool trackChanges);
    void CreateLike(Like like);
}
