
public class User
{
    public string? Username { get; set; }
    public string? PasswordHash { get; set; }
    public ICollection<Notice> Notices { get; set; } = new List<Notice>();
}