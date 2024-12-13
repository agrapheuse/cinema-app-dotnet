using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cinemaApp.Presentation.Controllers;

[Route("api/likes")]
[ApiController]
class LikeController : ControllerBase
{
    private readonly IServiceManager _service;

    public LikeController(IServiceManager service)
    {
        _service = service;
    }

    [HttpGet("user/{uuid}")]
    public IActionResult GetLikesOfUser(string uuid)
    {
        try
        {
            var movies = _service.LikeService.GetLikesOfUser(Guid.Parse(uuid), trackChanges: false);
            return Ok(movies);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpGet("user{userUuid}/movie/{movieUuid}")]
    public IActionResult IsMovieLikedByUser(string userUuid, string movieUuid)
    {
        try
        {
            var isLiked = _service.LikeService.IsMovieLikedByUser(Guid.Parse(userUuid), Guid.Parse(movieUuid), trackChanges: false);
            return Ok(isLiked);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

}
