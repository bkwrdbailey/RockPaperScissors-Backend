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

    [HttpPost("Session/Create")]
    public async Task createSession([FromBody] int userId)
    {
        await _service.sessionCreation(userId);
    }

    [HttpGet("Session/Validate/{userId}")]
    public async Task<bool> validateSession(int userId)
    {
        return await _service.checkSessionExpiration(userId);
    }

    [HttpDelete("Session/Remove/{userId}")]
    public async Task removeSession(int userId)
    {
        await _service.removeExpiredSessionViaId(userId);
    }
}