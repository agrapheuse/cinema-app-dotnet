using Entities.Models;
using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IMovieService
    {
        IEnumerable<MovieDto> GetAllMovies(bool trackChanges);
        IEnumerable<MovieDto> GetMoviesForCity(string city, bool trackChanges);
        MovieDto GetMovieById(Guid guid, bool trackChanges);
    }
}
