using System;
using Itmo.ObjectOrientedProgramming.Lab3.Entities;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;

public class TopicBuilder
{
    private string _name;
    private IAddressee? _addressee;

    public TopicBuilder()
    {
        _name = string.Empty;
        _addressee = null;
    }

    public TopicBuilder WithName(string name)
    {
        _name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public TopicBuilder WithAddressee(IAddressee addressee)
    {
        _addressee = addressee ?? throw new ArgumentNullException(nameof(addressee));

        return this;
    }

    public Topic Build()
    {
        if (string.IsNullOrEmpty(_name)) throw new ArgumentNullException(nameof(_name));
        if (_addressee is null) throw new ArgumentNullException(nameof(_addressee));

        return new Topic(_name, _addressee);
    }
}