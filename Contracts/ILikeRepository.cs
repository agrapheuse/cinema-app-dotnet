using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts;

public interface ILikeRepository
{
    IEnumerable<Movie> GetLikeOfUser(Guid guid, bool trackChanges);
    bool IsMovieLikedByUser(Guid userId, Guid movieId, bool trackChanges); 
}
