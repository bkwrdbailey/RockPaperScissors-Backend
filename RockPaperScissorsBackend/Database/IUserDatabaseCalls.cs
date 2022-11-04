using RockPaperScissorsBackend.Models;

namespace RockPaperScissorsBackend.DatabaseCalls;

public interface IUserDatabaseCalls
{
    Task<bool> addUser(UserDB newUser);
    Task<UserDB> getUser(string username);
}