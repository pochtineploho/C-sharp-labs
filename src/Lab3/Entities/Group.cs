using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class Group : IAddressee
{
    private readonly List<IAddressee> _addressees;

    public Group(IReadOnlyCollection<IAddressee> addressees)
    {
        _addressees = new List<IAddressee>(addressees ?? throw new ArgumentNullException(nameof(addressees)));
    }

    public void AddAddressee(IAddressee addressee)
    {
        if (addressee is null) throw new ArgumentNullException(nameof(addressee));

        _addressees.Add(addressee);
    }

    public void DeleteAddressee(IAddressee addressee)
    {
        if (addressee is null) throw new ArgumentNullException(nameof(addressee));

        _addressees.Remove(addressee);
    }

    public void ReceiveMessage(Message message)
    {
        if (message == null) throw new ArgumentNullException(nameof(message));

        foreach (IAddressee addressee in _addressees)
        {
            addressee.ReceiveMessage(message);
        }
    }
}