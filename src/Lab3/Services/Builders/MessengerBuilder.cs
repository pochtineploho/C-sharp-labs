#pragma warning disable CA1822
using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Proxies;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;

public class MessengerBuilder
{
    private IMessenger? _messenger;

    public MessengerBuilder WithMessenger(IMessenger messenger)
    {
        _messenger = messenger ?? throw new ArgumentNullException(nameof(messenger));

        return this;
    }

    public AddresseeFilterProxyBuilder WithLogger(ILogger logger)
    {
        if (logger is null) throw new ArgumentNullException(nameof(logger));
        if (_messenger is null) throw new WrongOrderBuilderException();

        return new AddresseeFilterProxyBuilder(
            new LoggerProxy(new MessengerAddressee(_messenger), logger));
    }
}