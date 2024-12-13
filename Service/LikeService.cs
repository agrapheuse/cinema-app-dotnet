using Contracts;
using Entities.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service;

internal sealed class LikeService : ILikeService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public LikeService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IEnumerable<Movie> GetLikesOfUser(Guid userId, bool trackChanges)
    {
        try
        {
            var movies = _repository.Like.GetLikeOfUser(userId, trackChanges);
            return movies;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetLikesOfUser)} service method {ex}");
            throw;
        }


    }

    public bool IsMovieLikedByUser(Guid userId, Guid movieId, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}
