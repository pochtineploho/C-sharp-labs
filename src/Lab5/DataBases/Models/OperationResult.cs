#pragma warning disable CA1034
namespace DataBases.Models;

public abstract record OperationResult(string Message)
{
    public string Message { get; } = Message;

    public sealed record Success(string Message) : OperationResult(Message);

    public sealed record Fail(string Message) : OperationResult(Message);
}