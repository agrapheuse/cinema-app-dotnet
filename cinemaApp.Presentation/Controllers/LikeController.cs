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

    [HttpGet("{id}/{userId}")]
    public async Task<IActionResult> GetLikesById(Guid id, Guid userId)
    {
        return StatusCode(500, "Not yet implemented");
    }
}
