using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IMovieService> _movieService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger)
    {
        _movieService = new Lazy<IMovieService>(() => new MovieService(repositoryManager, logger));
    }

    public IMovieService MovieService => _movieService.Value;
}
