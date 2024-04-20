using Itmo.ObjectOrientedProgramming.Lab3.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Models;

public interface IAddressee
{
    public void ReceiveMessage(Message message);
}