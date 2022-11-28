using RockPaperScissorsBackend.Models;

namespace RockPaperScissorsBackend.Services;

public interface ISessionService
{
    Task<bool> checkSessionExpiration(int userId);
    Task sessionCreation(int userId);
    Task removeExpiredSessionViaId(int userId);
    Task removeExpiredSessionViaRecord(UserSession sessionToRemove);
}