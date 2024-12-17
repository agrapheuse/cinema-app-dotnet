using AutoMapper;
using Contracts;
using Service.Contracts;

namespace Service;

public sealed class ServiceManager : IServiceManager
{
    private readonly Lazy<IMovieService> _movieService;
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<ICinemaService> _cinemaService;


    public ServiceManager(IRepositoryManager repositoryManager, ILoggerManager logger, IMapper mapper)
    {
        _movieService = new Lazy<IMovieService>(() => new MovieService(repositoryManager, logger, mapper));
        _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, logger, mapper));
        _cinemaService = new Lazy<ICinemaService>(() => new CinemaService(repositoryManager, logger, mapper));

    }

    public IMovieService MovieService => _movieService.Value;
    public IUserService UserService => _userService.Value;
    public ICinemaService CinemaService => _cinemaService.Value;
}
