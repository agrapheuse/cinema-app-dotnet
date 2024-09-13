using Contracts;
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
}
