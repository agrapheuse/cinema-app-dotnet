using Contracts;
using Entities.Models;

namespace Repository;

public class LikeRepository : RepositoryBase<Like>, ILikeRepository
{
    public LikeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Showing> GetLikesOfUser(Guid userUuid, bool trackChanges) =>
        FindByCondition(like => like.UserId == userUuid, trackChanges)
            .Select(like => like.Showing)
            .Where(movie => movie != null);


    public bool IsMovieLikedByUser(Guid userId, Guid movieId, bool trackChanges)
    {
        var like = FindByCondition(like => like.UserId == userId && like.UserId == movieId, trackChanges);
        return like != null;
    }

    public void CreateLike(Like like) => Create(like);
}
