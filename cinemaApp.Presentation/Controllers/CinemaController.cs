using Microsoft.AspNetCore.Mvc;
using Service.Contracts;

namespace cinemaApp.Presentation.Controllers;

[Route("api/cinemas")]
[ApiController]
public class CinemaController : ControllerBase
{
    private readonly IServiceManager _service;

    public CinemaController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("{city}")]
    public IActionResult GetCinemasByCity(string city)
    {
        try
        {
            var cinemas = _service.CinemaService.GetCinemaByCity(city, trackChanges: false);
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