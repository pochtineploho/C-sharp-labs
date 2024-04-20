namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IRepository<T>
{
    T? GetByName(string name);

    IRepository<T> Add(T component);
}