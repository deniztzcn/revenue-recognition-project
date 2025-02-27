namespace RevenueRecognition.Models.Domain;

public class AppUser
{
    public int IdUser { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Type { get; set; }
    
    public string Salt { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExp { get; set; }
}