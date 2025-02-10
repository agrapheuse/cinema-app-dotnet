using Contracts;
using Entities.Models;
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


    //[HttpPost]
    //public IActionResult CreateLike([FromBody] LikeForCreationDto likeDto)
    //{
    //    if (likeDto is null)
    //    {
    //        return BadRequest("Like data is null.");
    //    }

    //    var createdLike = _service.LikeService.CreateLike(likeDto);
    //    return CreatedAtRoute("GetLikeById", createdLike);
    //}

    [HttpGet("{id}/{userId}")]
    public async Task<IActionResult> GetLikeById(Guid id, Guid userId)
    {
        return StatusCode(500, "Not yet implemented");
    }
}
