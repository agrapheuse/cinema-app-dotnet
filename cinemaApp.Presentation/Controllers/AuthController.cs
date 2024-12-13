using Microsoft.AspNetCore.Mvc;
using Contracts;
using Google.Apis.Auth;

namespace cinemaApp.Presentation.Controllers;

[Route("auth")]
public class AuthController : ControllerBase
{
    private readonly ILoggerManager _logger;

    public AuthController(ILoggerManager logger)
    {
        _logger = logger;
    }

    [HttpPost("login")]
    public async Task<IActionResult> ExternalLogin([FromHeader(Name = "Authorization")] string authorization)
    {
        if (string.IsNullOrEmpty(authorization) || !authorization.StartsWith("Bearer "))
            return Unauthorized("No token provided.");


        var tokenId = authorization.Substring("Bearer ".Length).Trim();

        try
        {
            // Validate the token with Google
            var payload = await GoogleJsonWebSignature.ValidateAsync(tokenId);


            // Log or process information from the payload as needed
            _logger.LogInfo($"User authenticated: {payload.Email}, {payload.Name}");

            // Respond with the custom token or payload information
            return Ok(payload);
        }
        catch (InvalidJwtException)
        {
            _logger.LogError("Invalid token.");
            return Unauthorized("Invalid token.");
        }
    }
}
