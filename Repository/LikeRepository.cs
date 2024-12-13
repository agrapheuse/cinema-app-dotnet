using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class LikeRepository : RepositoryBase<Like>, ILikeRepository
{
    public LikeRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Like> GetLikeOfUser(Guid guid, bool trackChanges)
        {
            throw new NotImplementedException();
        }
}
