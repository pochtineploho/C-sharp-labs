using System;
using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Entities;

public class BasicFilter : IMessageFilter
{
    public BasicFilter(int importanceFilter = 0)
    {
        ImportanceFilter = importanceFilter;
    }

    public int ImportanceFilter { get; }

    public bool PassesFiltration(Message message)
    {
        if (message is null) throw new ArgumentNullException(nameof(message));

        if (message.ImportanceLevel < ImportanceFilter) return false;

        return true;
    }
}