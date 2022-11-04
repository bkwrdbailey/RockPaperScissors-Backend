using RockPaperScissorsBackend.Models;

namespace RockPaperScissorsBackend.Services;

public interface IUserService
{
    Task<bool> addNewUser(UserDB newUser);
    Task<UserDB> verifyUserLogin(string username);
}