using Contracts;
using Entities.Models;
using Service.Contracts;

namespace Service;

public sealed class MovieService : IMovieService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public MovieService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

    public IEnumerable<Movie> GetAllMovies(bool trackChanges)
    {
        try
        {
            var movies = _repository.Movie.GetAllMovies(trackChanges);
            return movies;
        } 
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllMovies)} service method {ex}");
            throw;
        }
    }

    public Movie GetMovieById(Guid guid, bool trackChanges)
    {
        try
        {
            var movie = _repository.Movie.GetMovieById(guid, trackChanges);
            return movie;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetMovieById)} service method {ex}");
            throw;
        }
    }
}
