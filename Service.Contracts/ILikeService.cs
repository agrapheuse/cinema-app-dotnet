using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts;

public interface ILikeService
{
    IEnumerable<Movie> GetLikesOfUser(Guid userId, bool trackChanges);
    bool IsMovieLikedByUser(Guid userId, Guid movieId, bool trackChanges);
}
