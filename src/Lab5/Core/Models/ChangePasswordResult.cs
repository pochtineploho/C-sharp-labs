#pragma warning disable CA1034
namespace Core.Models;

public abstract record ChangePasswordResult(string Message)
{
    public sealed record Success(string Message) : ChangePasswordResult(Message);

    public sealed record SameAsOld(string Message) : ChangePasswordResult(Message);

    public sealed record WrongFormat(string Message) : ChangePasswordResult(Message);
}