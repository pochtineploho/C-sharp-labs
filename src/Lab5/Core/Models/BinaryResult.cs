#pragma warning disable CA1034
namespace Core.Models;

public abstract record BinaryResult(string Message)
{
    public string Message { get; } = Message;

    public sealed record Success(string Message) : BinaryResult(Message);

    public sealed record Fail(string Message) : BinaryResult(Message);
}