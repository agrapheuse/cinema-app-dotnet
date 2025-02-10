using Microsoft.AspNetCore.Mvc;
using Contracts;
using Google.Apis.Auth;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace cinemaApp.Presentation.Controllers;

[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly ILoggerManager _logger;
    private readonly IServiceManager _service;


    public AuthController(ILoggerManager logger, IServiceManager service)
    {
        _service = service;
        _logger = logger;

    }

    [HttpPost("login")]
    public async Task<IActionResult> ExternalLogin([FromHeader(Name = "Authorization")] string authorization)
    {
        if (string.IsNullOrEmpty(authorization) || !authorization.StartsWith("Bearer "))
            return Unauthorized("No token provided.");


        var tokenId = authorization.Substring("Bearer ".Length).Trim();

        //TODO: do better
        try
        {
            // Validate the token with Google
            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenId);

            bool isUser = _service.UserService.IsUser(payload.Email, false);

            UserDto user;

            if (!isUser)
            {
                var userCreationDto = new UserForCreationDto(payload.Email, payload.Name);
                user = _service.UserService.CreateUser(userCreationDto);
            } else
            {
                user = _service.UserService.GetUserByEmail(payload.Email, false);
            }

            // Log or process information from the payload as needed
            _logger.LogInfo($"User authenticated: {payload.Email}, {payload.Name}");

            // Respond with the custom token or payload information
            return Ok(user);
        }
        catch (InvalidJwtException)
        {
            _logger.LogError("Invalid token.");
            return Unauthorized("Invalid token.");
        }
    }
}
