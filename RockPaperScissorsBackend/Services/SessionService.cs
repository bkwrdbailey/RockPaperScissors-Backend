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
            await removeExpiredSessionViaRecord(sessionRecord);
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
        UserSession userSession = await _db.getSessionRecord(userId);

        // Check if there is still an active session on record or not
        if (userSession.id == 0)
        {
            UserSession newSession = new UserSession();
            newSession.startSessionTime = DateTime.UtcNow;
            newSession.expSessionTime = newSession.startSessionTime.AddMinutes(30); // Add 20 - 30 minutes
            newSession.userId = userId;
            await _db.createSessionRecord(newSession);
        }
        else
        {
            userSession.startSessionTime = DateTime.UtcNow;
            userSession.expSessionTime = userSession.startSessionTime.AddMinutes(30);
            await _db.updateSessionRecord(userSession);
        }
    }

    // Remove a session record once it has expired via user id parameter
    public async Task removeExpiredSessionViaId(int userId)
    {
        UserSession sessionToRemove = await _db.getSessionRecord(userId);
        await _db.removeSessionRecord(sessionToRemove);
    }

    // Remove a session record once it has expired via UserSession object parameter
    public async Task removeExpiredSessionViaRecord(UserSession sessionToRemove)
    {
        await _db.removeSessionRecord(sessionToRemove);
    }
}