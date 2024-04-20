#pragma warning disable CA1034
namespace Core.Models;

public abstract record AbstractUser()
{
    public string? Id { get; set; }

    public sealed record User() : AbstractUser();

    public sealed record Admin() : AbstractUser();
}