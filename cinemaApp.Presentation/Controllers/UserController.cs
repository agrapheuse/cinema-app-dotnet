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
}