using Entities.Models;

namespace Service.Contracts
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies(string city, bool trackChanges);
        Movie GetMovieById(Guid guid, bool trackChanges);
        IEnumerable<string> GetAllCinemas(string city, bool trackChanges);
    }
}
