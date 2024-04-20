﻿using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IMessageFilter
{
    public bool PassesFiltration(Message message);
}