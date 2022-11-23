using RockPaperScissorsBackend.Models;

namespace RockPaperScissorsBackend.Services;

public interface ISessionService
{
    Task<bool> checkSessionExpiration(int userId);
    Task sessionCreation(int userId);
    Task removeExpiredSession(UserSession sessionToRemove);
}