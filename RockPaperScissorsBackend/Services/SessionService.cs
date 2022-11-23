using RockPaperScissorsBackend.Models;
using RockPaperScissorsBackend.DatabaseCalls;

namespace RockPaperScissorsBackend.Services;

public class SessionService : ISessionService
{
    private readonly ISessionDatabaseCalls _db;
    public SessionService(ISessionDatabaseCalls db)
    {
        _db = db;
    }

    // Verify if the Session has expired or not (aka if it is still valid)
    public async Task<bool> checkSessionExpiration(int userId)
    {
        UserSession sessionRecord = await _db.getSessionRecord(userId);

        // Conditional to remove session record or update it based on whether time has expired or not
        if (DateTime.UtcNow > sessionRecord.expSessionTime)
        {
            await removeExpiredSession(sessionRecord);
            return false;
        }
        else
        {
            sessionRecord.expSessionTime = DateTime.UtcNow;
            sessionRecord.expSessionTime.AddMinutes(30);
            await _db.updateSessionRecord(sessionRecord);
            return true;
        }
    }

    // Acquire current date time for session record creation
    public async Task sessionCreation(int userId)
    {
        UserSession newSession = new UserSession();
        newSession.startSessionTime = DateTime.UtcNow;
        newSession.expSessionTime = newSession.startSessionTime.AddMinutes(30); // Add 20 - 30 minutes
        newSession.userId = userId;

        await _db.createSessionRecord(newSession);
    }

    // Remove a session record once it has expired
    public async Task removeExpiredSession(UserSession sessionToRemove)
    {
        await _db.removeSessionRecord(sessionToRemove);
    }
}