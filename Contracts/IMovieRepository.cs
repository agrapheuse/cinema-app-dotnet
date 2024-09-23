using Entities.Models;

namespace Contracts;

public interface IMovieRepository
{
    IEnumerable<Movie> GetAllMovies(bool trackChanges);
    IEnumerable<Movie> GetMoviesForCity(string city, bool trackChanges);
    Movie GetMovieById(Guid guid, bool trackChanges);
    IEnumerable<string> GetAllCinemas(string city, bool trackChanges);
}
