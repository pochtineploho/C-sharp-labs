namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Order
{
    public Order(Computer? computer, string comment = "")
    {
        Computer = computer;
        Comment = comment;
    }

    public Computer? Computer { get; }
    public string Comment { get; }
}