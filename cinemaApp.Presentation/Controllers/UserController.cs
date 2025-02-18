using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace cinemaApp.Presentation.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IServiceManager _service;

    public UserController(IServiceManager service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserForCreationDto userDto)
    {
        if (userDto is null)
        {
            return BadRequest("User data is null.");
        }

        var createdUser = _service.UserService.CreateUser(userDto);
        return CreatedAtRoute("GetUserById", new { id = createdUser.Uuid }, createdUser);
    }

    [HttpGet("{id}", Name = "GetUserById")]
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
        catch (Exception e)
        {
            return StatusCode(500, "Internal Server Error: " + e);
        }
    }

    [HttpGet("userExists/{email}")]
    public IActionResult UserExists(string email)
    {
        try
        {
            var user = _service.UserService.IsUser(email, trackChanges: false);
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


    [HttpGet("byEmail/{email}")]
    public IActionResult GetUserByEmail(string email)
    {
        try
        {
            var user = _service.UserService.GetUserByEmail(email, trackChanges: false);
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

    [HttpGet("{userUuid}/movie/{movieUuid}")]
    public IActionResult IsMovieLikedByUser(string userUuid, string movieUuid)
    {
        try
        {
            var isLiked = _service.UserService.IsMovieLikedByUser(Guid.Parse(userUuid), Guid.Parse(movieUuid), trackChanges: false);
            return Ok(isLiked);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPost("like")]
    public IActionResult CreateLike([FromBody] LikeForCreationDto likeDto)
    {
        if (likeDto is null)
        {
            return BadRequest("Like data is null.");
        }

        var createdLike = _service.UserService.CreateLike(likeDto);
        return Created();
    }

    [HttpGet("{userUuid}/likes")]
    public IActionResult GetLikesOfUser(string userUuid)
    {
        try
        {
            var isLiked = _service.UserService.getLikesOfUser(Guid.Parse(userUuid), trackChanges: false);
            return Ok(isLiked);
        }
        catch (Exception)
        {
            return StatusCode(500, "Internal Server Error");
        }
    }


}