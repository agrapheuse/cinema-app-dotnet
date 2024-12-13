using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IMovieService> _movieService;
    private readonly Lazy<ILikeService> _likeService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, Lazy<ILikeService> likeService)
    {
        _likeService = likeService;
        _movieService = new Lazy<IMovieService>(() => new MovieService(repositoryManager, logger));
    }

    public IMovieService MovieService => _movieService.Value;
    public ILikeService LikeService => _likeService.Value;

}
