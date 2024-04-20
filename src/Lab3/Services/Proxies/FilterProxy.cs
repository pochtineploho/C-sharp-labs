using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Proxies;

public class FilterProxy : IAddressee
{
    private readonly LoggerProxy _addressee;
    private readonly IMessageFilter _filter;

    public FilterProxy(LoggerProxy addressee, IMessageFilter filter)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));
        _filter = filter ?? throw new ArgumentNullException(nameof(filter));
    }

    public void ReceiveMessage(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));
        if (!_filter.PassesFiltration(message)) return;

        _addressee.ReceiveMessage(message);
    }
}