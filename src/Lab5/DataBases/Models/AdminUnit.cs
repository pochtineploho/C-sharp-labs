namespace DataBases.Models;

public record AdminUnit(string Username, string Password)
{
    public string Username { get; } = Username ?? throw new ArgumentNullException(nameof(Username));
    public string Password { get; } = Password ?? throw new ArgumentNullException(nameof(Password));
}