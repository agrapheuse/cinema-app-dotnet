using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class LikeRepository : RepositoryBase<Like>, ILikeRepository
{
    public LikeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Showing> GetLikesOfUser(Guid userUuid, bool trackChanges) =>
        FindByCondition(like => like.UserId == userUuid, trackChanges)
            .Include(like => like.Showing)
            .ThenInclude(showing => showing.Movie)
            .ThenInclude(movie => movie.Cinema)
            .Select(like => like.Showing)
            .Where(showing => showing != null)
            .ToList();



    public bool IsMovieLikedByUser(Guid userId, Guid movieId, bool trackChanges)
    {
        var like = FindByCondition(like => like.UserId == userId && like.UserId == movieId, trackChanges);
        return like != null;
    }

    public void CreateLike(Like like) => Create(like);
}
