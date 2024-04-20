using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class User : IAddressee
{
    private readonly List<UserMessage> _messages;

    public User(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;
        _messages = new List<UserMessage>();
    }

    public string Name { get; }

    public void SetMessageRead(string header)
    {
        foreach (UserMessage message in _messages.Where(message => message.Message.Header == header))
        {
            message.ReadMessage();
        }
    }

    public void ReceiveMessage(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        _messages.Add(new UserMessage(message));
    }

    public MessageStatus GetMessageStatus(string header)
    {
        UserMessage foundMessage = _messages.Find(message => message.Message.Header == header) ??
                                    throw new DoesntExistException();

        return foundMessage.Status;
    }
}