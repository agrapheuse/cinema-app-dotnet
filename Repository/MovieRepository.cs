using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    public MovieRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Movie> GetAllMovies(bool trackChanges) =>
        FindAll(trackChanges).Include(movie => movie.Showings);

    public IEnumerable<Movie> GetMoviesForCity(string city, bool trackChanges) =>
        FindByCondition(movie => movie.Showings.Any(showing => showing.Cinema.City == city), trackChanges)
            .Include(movie => movie.Showings)
            .ThenInclude(showing => showing.Cinema)
            .ToList();

    public Movie GetMovieById(Guid guid, bool trackChanges) =>
        FindByCondition(movie => movie.Uuid == guid, trackChanges).FirstOrDefault();
}