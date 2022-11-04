using RockPaperScissorsBackend.Models;
using RockPaperScissorsBackend.DatabaseCalls;

namespace RockPaperScissorsBackend.Services;

public class UserService : IUserService
{
    private readonly IUserDatabaseCalls _db;
    public UserService(IUserDatabaseCalls db)
    {
        _db = db;
    }

    public async Task<bool> addNewUser(UserDB newUser)
    {
        return await _db.addUser(newUser);
    }

    public async Task<UserDB> verifyUserLogin(string username)
    {
        return await _db.getUser(username);
    }
}