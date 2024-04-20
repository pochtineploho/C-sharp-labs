namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public interface IBuilder<T>
{
    void Reset();

    T GetResult();
}