
namespace RockPaperScissorsBackend.Models;

public class UserDB
{
    public int id { get; set; }
    public string? username { get; set; }
    public string? password { get; set; }
    public string? salt { get; set; }
}