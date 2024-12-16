using Contracts;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public class CinemaRepository : RepositoryBase<Cinema>, ICinemaRepository
{
    public CinemaRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Cinema> getAllCinemas(bool trackChanges)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Cinema> getCinemaById(Guid id, bool trackChanges)
    {
        throw new NotImplementedException();
    }
}