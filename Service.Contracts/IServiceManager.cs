namespace Service.Contracts
{
    public interface IServiceManager
    {
        IMovieService MovieService { get; }
        IUserService UserService { get; }
        ICinemaService CinemaService { get; }
    }
}
