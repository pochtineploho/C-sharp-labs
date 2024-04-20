using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Adapters;

public class DisplayAddressee : IAddressee
{
    private readonly Message _defaultMessage = new("No new messages", string.Empty);
    private readonly IDisplay _display;
    private Message _message;

    public DisplayAddressee(IDisplay display)
    {
        _display = display ?? throw new ArgumentNullException(nameof(display));
        _message = _defaultMessage;
    }

    public void ReceiveMessage(Message message)
    {
        _message = message ?? throw new ArgumentNullException(nameof(message));
        _display.Write(_message.ToText());
    }
}