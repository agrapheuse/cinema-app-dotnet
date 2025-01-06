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
        FindAll(trackChanges)
            .Where(movie => movie.Showings.Any()) // Exclude Movies without Showings
            .Include(movie => movie.Showings)
            .Include(movie => movie.Cinema)
            .ToList();

    public IEnumerable<Movie> GetMoviesForCity(string city, bool trackChanges) =>
        FindByCondition(movie => movie.Cinema.City == city, trackChanges)
            .Where(movie => movie.Showings.Any()) // Exclude Movies without Showings
            .Include(movie => movie.Showings)
            .Include(movie => movie.Cinema)
            .ToList();

    public Movie GetMovieById(Guid guid, bool trackChanges) =>
        FindByCondition(movie => movie.Uuid == guid, trackChanges).FirstOrDefault();
}