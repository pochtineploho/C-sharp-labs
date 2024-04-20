#pragma warning disable CA1034
namespace Core.Models;

public abstract record LoginResult(string Message)
{
    public sealed record Success(string Message) : LoginResult(Message);

    public sealed record NotFound(string Message) : LoginResult(Message);

    public sealed record WrongPassword(string Message) : LoginResult(Message);
}