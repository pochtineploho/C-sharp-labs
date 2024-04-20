using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public record UserMessage
{
    public UserMessage(Message message)
    {
        Message = message;
        Status = MessageStatus.Delivered;
    }

    public Message Message { get; }
    public MessageStatus Status { get; private set; }

    public void ReadMessage()
    {
        if (Status == MessageStatus.Read) throw new AlreadyReadException();

        Status = MessageStatus.Read;
    }
}