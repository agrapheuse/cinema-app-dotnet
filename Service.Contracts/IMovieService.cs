﻿using Entities.Models;

namespace Service.Contracts
{
    public interface IMovieService
    {
        IEnumerable<Movie> GetAllMovies(bool trackChanges);
        Movie GetMovieById(Guid guid, bool trackChanges);
    }
}
