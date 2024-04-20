namespace Itmo.ObjectOrientedProgramming.Lab4.Parser.Entities.Fabrics;

public interface IFabric<T>
{
    T? GetByName(string name);
}