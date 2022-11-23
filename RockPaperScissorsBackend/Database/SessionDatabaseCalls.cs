using RockPaperScissorsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissorsBackend.DatabaseCalls;

public class SessionDatabaseCalls : ISessionDatabaseCalls
{
    private readonly RockPaperScissorsDBContext _context;
    public SessionDatabaseCalls(RockPaperScissorsDBContext context)
    {
        _context = context;
    }

    public async Task<UserSession> createSessionRecord(UserSession newSession)
    {
        await _context.Sessions.AddAsync(newSession);
        await _context.SaveChangesAsync();

        return newSession;
    }

    public async Task<UserSession> getSessionRecord(int userId)
    {
        UserSession currSession = await _context.Sessions.FirstOrDefaultAsync<UserSession>(session => userId == session.id) ?? new UserSession();
        return currSession;
    }

    public async Task updateSessionRecord(UserSession updatedSession)
    {
        _context.Sessions.Update(updatedSession);
        await _context.SaveChangesAsync();
    }

    public async Task removeSessionRecord(UserSession sessionToRemove)
    {
        _context.Sessions.Remove(sessionToRemove);
        await _context.SaveChangesAsync();
    }
}