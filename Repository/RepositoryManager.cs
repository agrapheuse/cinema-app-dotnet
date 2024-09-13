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

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _movieRepository = new Lazy<IMovieRepository>(
            () => new MovieRepository(repositoryContext)
            );
    }

    public IMovieRepository Movie => _movieRepository.Value;

    public void Save() => _repositoryContext.SaveChanges();
}
