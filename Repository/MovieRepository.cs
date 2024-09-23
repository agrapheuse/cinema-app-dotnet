using Contracts;
using Entities.Models;

namespace Repository;

public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    public MovieRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Movie> GetAllMovies(bool trackChanges) =>
        FindAll(trackChanges);
    public IEnumerable<Movie> GetMoviesForCity(string city, bool trackChanges) =>
        FindByCondition(movie => movie.City == city, trackChanges).OrderBy(movie => movie.DateTime);

    public Movie GetMovieById(Guid guid, bool trackChanges) =>
        FindByCondition(movie => movie.Uuid == guid, trackChanges).FirstOrDefault();

    public IEnumerable<string> GetAllCinemas(string city, bool trackChanges) =>
        FindByCondition(movie => movie.City == city, trackChanges) 
            .Select(movie => movie.Cinema)
            .Distinct()
            .ToList();
}
