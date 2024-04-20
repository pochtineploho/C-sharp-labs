using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Proxies;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;

public class GroupBuilder : IAddresseeLoggerProxyBuilder
{
    private List<IAddressee> _addressees = new();

    public IAddresseeLoggerProxyBuilder AddAddressees(IReadOnlyCollection<FilterProxy> addressees)
    {
        _addressees = new List<IAddressee>(addressees ?? throw new ArgumentNullException(nameof(addressees)));

        return this;
    }

    public AddresseeFilterProxyBuilder WithLogger(ILogger logger)
    {
        if (_addressees.Capacity == 0) throw new WrongOrderBuilderException();

        return new AddresseeFilterProxyBuilder(new LoggerProxy(new Group(_addressees), logger));
    }
}