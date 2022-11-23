using Microsoft.EntityFrameworkCore;
using RockPaperScissorsBackend.Models;

namespace RockPaperScissorsBackend.DatabaseCalls;

public class RockPaperScissorsDBContext : DbContext
{
    public RockPaperScissorsDBContext() : base() { }
    public RockPaperScissorsDBContext(DbContextOptions options) : base(options) { }
    public DbSet<UserDB> Users { get; set; }
    public DbSet<UserSession> Sessions { get; set; }
}