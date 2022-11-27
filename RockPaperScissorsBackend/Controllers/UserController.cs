using Microsoft.AspNetCore.Mvc;
using RockPaperScissorsBackend.Models;
using RockPaperScissorsBackend.Services;

[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _service;
    public UserController(IUserService service)
    {
        _service = service;
    }

    [HttpGet("User/Verify/{username}")]
    public async Task<UserDB> verifyUserLogin(string username)
    {
        return await _service.verifyUserLogin(username);
    }

    [HttpPost("User/NewUser")]
    public async Task<bool> newUserSignUp([FromBody] UserDB newUser)
    {
        return await _service.addNewUser(newUser);
    }
}