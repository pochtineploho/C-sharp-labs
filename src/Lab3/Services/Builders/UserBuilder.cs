using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Exceptions;
using Itmo.ObjectOrientedProgramming.Lab3.Models;
using Itmo.ObjectOrientedProgramming.Lab3.Services.Proxies;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;

public class UserBuilder : IAddresseeLoggerProxyBuilder
{
    private string _name = string.Empty;
    private User? _user;

    public UserBuilder(User? user = null)
    {
        _user = user;
        if (user is not null) _name = user.Name;
    }

    public UserBuilder WithName(string name)
    {
        if (_user is not null) throw new WrongOrderBuilderException();
        _name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public AddresseeFilterProxyBuilder WithLogger(ILogger logger)
    {
        if (string.IsNullOrEmpty(_name)) throw new WrongOrderBuilderException();
        _user ??= new User(_name);

        return new AddresseeFilterProxyBuilder(new LoggerProxy(_user, logger));
    }
}