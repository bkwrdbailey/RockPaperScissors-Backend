using RockPaperScissorsBackend.Models;

namespace RockPaperScissorsBackend.DatabaseCalls;

public interface ISessionDatabaseCalls
{
    Task<UserSession> createSessionRecord(UserSession newSession);
    Task<UserSession> getSessionRecord(int userId);
    Task updateSessionRecord(UserSession updatedSession);
    Task removeSessionRecord(UserSession sessionToRemove);
}