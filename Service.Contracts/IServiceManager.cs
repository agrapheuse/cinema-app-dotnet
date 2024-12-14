namespace Service.Contracts
{
    public interface IServiceManager
    {
        IMovieService MovieService { get; }
        ILikeService LikeService { get; }
        IUserService UserService { get; }
    }
}
