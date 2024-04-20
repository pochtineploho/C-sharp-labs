using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Adapters;

public class MessengerAdapter : IMessenger
{
    private readonly Messenger.Messenger _messenger;

    public MessengerAdapter(Messenger.Messenger messenger)
    {
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));
    }

    public void Write(string text)
    {
        _messenger.Print(text);
    }
}