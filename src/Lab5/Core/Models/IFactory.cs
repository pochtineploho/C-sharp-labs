namespace Core.Models;

public interface IFactory<out T>
{
    T Create();
}