using Contracts;
using Entities.Models;
using Service.Contracts;
using System;
using AutoMapper;

namespace Service;

public sealed class MovieService : IMovieService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public MovieService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

    public IEnumerable<Movie> GetAllMovies(bool trackChanges)
    {
        try
        {
            var movies = _repository.Movie.GetAllMovies(trackChanges);
            return movies;
        } 
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllMovies)} service method {ex}");
            throw;
        }
    }

    /* TODOOOOOO: improve service bc this SUX
     *public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
       {
           try
           {
               // Fetch companies from the repository
               var companies = _repository.Company.GetAllCompanies(trackChanges);
       
               // Map entities to DTOs
               var companiesDto = companies.Select(c => new CompanyDto(
                   c.Id,
                   c.Name ?? string.Empty, // Ensure null-safe handling for Name
                   string.Join(' ', new[] { c.Address, c.Country }.Where(s => !string.IsNullOrEmpty(s))) // Handle null/empty strings in Address and Country
               )).ToList();
       
               return companiesDto;
           }
           catch (Exception ex)
           {
               // Log the error and rethrow the exception
               _logger.LogError($"An error occurred in the {nameof(GetAllCompanies)} service method: {ex}");
               throw;
           }
       }
     */

    public IEnumerable<Movie> GetMoviesForCity(string city, bool trackChanges)
    {
        try
        {
            var movies = _repository.Movie.GetMoviesForCity(city, trackChanges);
            return movies;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetMoviesForCity)} service method {ex}");
            throw;
        }
    }

    public Movie GetMovieById(Guid guid, bool trackChanges)
    {
        try
        {
            var movie = _repository.Movie.GetMovieById(guid, trackChanges);
            return movie;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetMovieById)} service method {ex}");
            throw;
        }
    }

    public IEnumerable<string> GetAllCinemas(string city, bool trackChanges)
    {
        try
        {
            var cinemas = _repository.Movie.GetAllCinemas(city, trackChanges);
            return cinemas;
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllCinemas)} service method {ex}");
            throw;
        }
    }
}
