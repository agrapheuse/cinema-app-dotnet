using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;
    private readonly Lazy<IMovieRepository> _movieRepository;
    private readonly Lazy<ILikeRepository> _likeRepository;
    private readonly Lazy<IUserRepository> _userRepository;


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
    }

    public IMovieRepository Movie => _movieRepository.Value;
    public ILikeRepository Like => _likeRepository.Value;
    public IUserRepository User => _userRepository.Value;


    public void Save() => _repositoryContext.SaveChanges();
}
