using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace cinemaApp.Presentation.Controllers;

[Route("api/likes")]
[ApiController]
public class LikeController : ControllerBase
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

    [HttpPost]
    public IActionResult CreateLike([FromBody] LikeForCreationDto likeDto)
    {
        if (likeDto is null)
        {
            return BadRequest("Like data is null.");
        }

        var createdLike = _service.LikeService.CreateLike(likeDto);
        return CreatedAtRoute("GetLikeById", new { id = createdLike.Uuid }, createdLike);
    }

    [HttpGet("{id}", Name = "GetLikeById")]
    public IActionResult GetUserById(string id)
    {
        try
        {
            var user = _service.UserService.GetUserById(Guid.Parse(id), trackChanges: false);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }


}
