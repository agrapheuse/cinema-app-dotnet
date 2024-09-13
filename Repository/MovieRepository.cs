using Contracts;
using Entities.Models;

namespace Repository;

public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    public MovieRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }
}
