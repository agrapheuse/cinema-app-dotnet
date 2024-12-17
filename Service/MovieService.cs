using AutoMapper;
using Contracts;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service;

public sealed class MovieService : IMovieService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public MovieService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<MovieDto> GetAllMovies(bool trackChanges)
    {
        try
        {
            var movies = _repository.Movie.GetAllMovies(trackChanges);

            var movieDtos = movies.Select(m => new MovieDto(
                m.Uuid,
                m.Title,
                m.Director ?? string.Empty,
                m.Category ?? string.Empty,
                m.Description ?? string.Empty,
                m.Cinema.Uuid,
                m.DateTime,
                m.ImageUrl,
                m.InfoLink,
                m.TicketLink ?? string.Empty
                )).ToList();

            return movieDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred in the {nameof(GetAllMovies)} service method: {ex}");
            throw;
        }
    }

    public IEnumerable<MovieDto> GetMoviesForCity(string city, bool trackChanges)
    {
        try
        {
            var movies = _repository.Movie.GetMoviesForCity(city, trackChanges);
            var movieDtos = movies.Select(m => new MovieDto(
                m.Uuid,
                m.Title,
                m.Director ?? string.Empty,
                m.Category ?? string.Empty,
                m.Description ?? string.Empty,
                m.Cinema.Uuid,
                m.DateTime,
                m.ImageUrl,
                m.InfoLink,
                m.TicketLink ?? string.Empty
            )).ToList();

            return movieDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetMoviesForCity)} service method {ex}");
            throw;
        }
    }

    public MovieDto GetMovieById(Guid guid, bool trackChanges)
    {
        try
        {
            var movie = _repository.Movie.GetMovieById(guid, trackChanges);
            return new MovieDto(
                movie.Uuid,
                movie.Title,
                movie.Director ?? string.Empty,
                movie.Category ?? string.Empty,
                movie.Description ?? string.Empty,
                movie.Cinema.Uuid,
                movie.DateTime,
                movie.ImageUrl,
                movie.InfoLink,
                movie.TicketLink ?? string.Empty
                );
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetMovieById)} service method {ex}");
            throw;
        }
    }

    public IEnumerable<MovieDto> GetLikesOfUser(Guid userId, bool trackChanges)
    {
        try
        {
            var movies = _repository.Like.GetLikeOfUser(userId, trackChanges);
            var movieDtos = movies.Select(m => new MovieDto(
                m.Uuid,
                m.Title,
                m.Director ?? string.Empty,
                m.Category ?? string.Empty,
                m.Description ?? string.Empty,
                m.Cinema.Uuid,
                m.DateTime,
                m.ImageUrl,
                m.InfoLink,
                m.TicketLink ?? string.Empty
            )).ToList();

            return movieDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetLikesOfUser)} service method {ex}");
            throw;
        }
    }
}
