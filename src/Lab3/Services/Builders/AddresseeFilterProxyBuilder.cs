using System;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Proxies;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;

public class AddresseeFilterProxyBuilder
{
    private readonly LoggerProxy _logger;
    private FilterProxy? _filter;

    public AddresseeFilterProxyBuilder(LoggerProxy logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _filter = null;
    }

    public IAddressee WithFilter(IMessageFilter filter)
    {
        if (filter is null) throw new ArgumentNullException(nameof(filter));
        if (_filter is not null) throw new WrongOrderBuilderException(nameof(filter));

        _filter = new FilterProxy(_logger, filter);

        return Build();
    }

    private FilterProxy Build()
    {
        if (_filter is null) throw new ArgumentNullException(nameof(_filter));
        return _filter;
    }
}