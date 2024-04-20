using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Topic
{
    private IAddressee _addressee;

    public Topic(string name, IAddressee addressee)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
    }

    public string Name { get; }

    public void SetAddressee(IAddressee addressee)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
    }

    public void ReceiveMessage(Message message)
    {
        _addressee.ReceiveMessage(message);
    }
}