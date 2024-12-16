using Contracts;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IMovieRepository> _movieRepository;
    private readonly Lazy<ILikeRepository> _likeRepository;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<ICinemaRepository> _cinemaRepository;
    private readonly Lazy<IUserCinemaRepository> _userCinemaRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _movieRepository = new Lazy<IMovieRepository>(
            () => new MovieRepository(repositoryContext)
            );
        _likeRepository = new Lazy<ILikeRepository>(
            () => new LikeRepository(repositoryContext)
            );
        _userRepository = new Lazy<IUserRepository>(
            () => new UserRepository(repositoryContext)
            );
        _cinemaRepository = new Lazy<ICinemaRepository>(
            () => new CinemaRepository(repositoryContext)
        );
        _userCinemaRepository = new Lazy<IUserCinemaRepository>(
            () => new UserCinemaRepository(repositoryContext)
        );
    }

    public IMovieRepository Movie => _movieRepository.Value;
    public ILikeRepository Like => _likeRepository.Value;
    public IUserRepository User => _userRepository.Value;
    public ICinemaRepository Cinema => _cinemaRepository.Value;
    public IUserCinemaRepository UserCinema => _userCinemaRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();
}
