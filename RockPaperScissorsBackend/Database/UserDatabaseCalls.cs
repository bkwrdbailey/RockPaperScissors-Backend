using RockPaperScissorsBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace RockPaperScissorsBackend.DatabaseCalls;

public class UserDatabaseCalls : IUserDatabaseCalls
{
    private readonly RockPaperScissorsDBContext _context;
    public UserDatabaseCalls(RockPaperScissorsDBContext context)
    {
        _context = context;
    }

    public async Task<bool> addUser(UserDB newUser)
    {
        // Checking to see if the user does not already exists
        if ( !(await _context.Users.AnyAsync(user => user.username == newUser.username)) )
        {
            await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<UserDB> getUser(string username)
    {
        return await _context.Users.FirstOrDefaultAsync<UserDB>(user => user.username == username) ?? new UserDB();
    }
}