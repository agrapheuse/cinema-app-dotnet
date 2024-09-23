using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace cinemaApp.Presentation.Controllers;

[Route("api/movies")]
[ApiController]
public class MovieController : ControllerBase
{
    private readonly IServiceManager _service;

    public MovieController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet]
    public IActionResult GetMovies()
    {
        try
        {
            var movies = _service.MovieService.GetAllMovies(trackChanges: false).Take(10);
            return Ok(movies);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }


    [HttpGet("{city}")]
    public IActionResult GetMoviesForCity(string city)
    {
        try
        {
            var movies = _service.MovieService.GetMoviesForCity(city, trackChanges: false).Take(10);
            return Ok(movies);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("movie/{uuid}")]
    public IActionResult GetMovieById(string uuid)
    {
        try
        {
            var movie = _service.MovieService.GetMovieById(Guid.Parse(uuid), trackChanges: false);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("cinemas/{city}")]
    public IActionResult GetCinemasByCity(string city)
    {
        try
        {
            var cinemas = _service.MovieService.GetAllCinemas(city, trackChanges: false);
            if (cinemas == null)
            {
                return NotFound();
            }
            return Ok(cinemas);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

}
