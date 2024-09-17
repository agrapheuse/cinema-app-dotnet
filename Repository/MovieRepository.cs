﻿using Contracts;
using Entities.Models;

namespace Repository;

public class MovieRepository : RepositoryBase<Movie>, IMovieRepository
{
    public MovieRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
    }

    public IEnumerable<Movie> GetAllMovies(bool trackChanges) =>
        FindAll(trackChanges).OrderBy(c => c.DateTime).ToList();

    public Movie GetMovieById(Guid guid, bool trackChanges) =>
        FindByCondition(movie => movie.Uuid == guid, trackChanges).FirstOrDefault();

    public IEnumerable<string> GetAllCinemas(string city, bool trackChanges) =>
        FindByCondition(movie => movie.City == city, trackChanges) 
            .Select(movie => movie.Cinema)
            .Distinct()
            .ToList();
}
