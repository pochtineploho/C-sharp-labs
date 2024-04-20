using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Proxies;

public class LoggerProxy : IAddressee
{
    private readonly IAddressee _addressee;
    private readonly ILogger _logger;

    public LoggerProxy(IAddressee addressee, ILogger logger)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public void ReceiveMessage(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));
        _logger.Log(message.ToText());
        _addressee.ReceiveMessage(message);
    }
}