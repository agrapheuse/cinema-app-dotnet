namespace Contracts;

public interface IRepositoryManager
{
    IMovieRepository Movie { get; }
    ILikeRepository Like { get; }
    IUserRepository User { get; }
    ICinemaRepository Cinema { get; }
    IUserCinemaRepository UserCinema { get; }

    void Save();
}
