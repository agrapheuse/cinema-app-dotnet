using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IMovieService> _movieService;
    private readonly Lazy<ILikeService> _likeService;
    private readonly Lazy<IUserService> _userService;

    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _movieService = new Lazy<IMovieService>(() => new MovieService(repositoryManager, logger, mapper));
        _likeService = new Lazy<ILikeService>(() => new LikeService(repositoryManager, logger, mapper));
        _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger, mapper));
    }

    public IMovieService MovieService => _movieService.Value;
    public ILikeService LikeService => _likeService.Value;
    public IUserService UserService => _userService.Value;
}
