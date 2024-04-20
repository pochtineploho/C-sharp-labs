using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Adapters;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Proxies;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;

public class DisplayWithDriverBuilder : IAddresseeLoggerProxyBuilder
{
    private IDisplay? _display;

    public DisplayWithDriverBuilder WithDisplay(IDisplay display)
    {
        _display = display ?? throw new ArgumentNullException(nameof(display));

        return this;
    }

    public AddresseeFilterProxyBuilder WithLogger(ILogger logger)
    {
        if (logger is null) throw new ArgumentNullException(nameof(logger));
        if (_display is null) throw new WrongOrderBuilderException();

        return new AddresseeFilterProxyBuilder(new LoggerProxy(new DisplayAddressee(_display), logger));
    }
}