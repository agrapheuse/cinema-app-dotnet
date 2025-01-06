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

            var movieDtos = movies.Select(movie => new MovieDto(
                movie.Uuid,
                movie.Title,
                movie.Director ?? string.Empty,
                movie.Category ?? string.Empty,
                movie.Description ?? string.Empty,
                movie.ImageUrl ?? string.Empty,
                new CinemaDto(
                    movie.Cinema.Uuid,
                    movie.Cinema.Name,
                    movie.Cinema.Country,
                    movie.Cinema.City,
                    movie.Cinema.Color,
                    movie.Cinema.LogoUrl
                ),
                movie.Showings.Select(showing => new ShowingDto(
                    showing.Uuid,
                    showing.DateTime,
                    showing.InfoLink ?? string.Empty,
                    showing.TicketLink
                )).ToList()
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

            var movieDtos = movies.Select(movie => new MovieDto(
                movie.Uuid,
                movie.Title,
                movie.Director ?? string.Empty,
                movie.Category ?? string.Empty,
                movie.Description ?? string.Empty,
                movie.ImageUrl ?? string.Empty,
                new CinemaDto(
                    movie.Cinema.Uuid,
                    movie.Cinema.Name,
                    movie.Cinema.Country,
                    movie.Cinema.City,
                    movie.Cinema.Color,
                    movie.Cinema.LogoUrl
                ),
                movie.Showings.Select(showing => new ShowingDto(
                    showing.Uuid,
                    showing.DateTime,
                    showing.InfoLink ?? string.Empty,
                    showing.TicketLink
                )).ToList()
            )).ToList();

            return movieDtos;
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred in the {nameof(GetAllMovies)} service method: {ex}");
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
                movie.ImageUrl ?? string.Empty,
                new CinemaDto(
                    movie.Cinema.Uuid,
                    movie.Cinema.Name,
                    movie.Cinema.Country,
                    movie.Cinema.City,
                    movie.Cinema.Color,
                    movie.Cinema.LogoUrl
                ),
                movie.Showings.Select(showing => new ShowingDto(
                    showing.Uuid,
                    showing.DateTime,
                    showing.InfoLink ?? string.Empty,
                    showing.TicketLink
                )).ToList()
            );
        }
        catch (Exception ex)
        {
            _logger.LogError($"An error occurred in the {nameof(GetAllMovies)} service method: {ex}");
            throw;
        }
    }
}