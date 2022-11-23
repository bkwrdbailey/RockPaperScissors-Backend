namespace RockPaperScissorsBackend.Models;

public class UserSession
{
    // Unique identity for every session record (PK)
    public int id { get; set; }
    // Unique identity tied to the user who has signed in
    public int userId { get; set; }
    // When user first successfully logs in
    public DateTime startSessionTime { get; set; }
    // Amount of time until session is invalid and a re-login will be required
    public DateTime expSessionTime { get; set; }
}