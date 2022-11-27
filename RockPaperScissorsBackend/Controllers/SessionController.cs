using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsBackend.Models;
using RockPaperScissorsBackend.Services;

[ApiController]
public class SessionController : ControllerBase
{
    private readonly ISessionService _service;
    public SessionController(ISessionService service)
    {
        _service = service;
    }

    [HttpPost("Session/Create/{userId}")]
    public async Task createSession(int userId)
    {
        await _service.sessionCreation(userId);
    }

    [HttpGet("Session/Validate/{userId}")]
    public async Task<bool> validateSession(int userId)
    {
        return await _service.checkSessionExpiration(userId);
    }
}