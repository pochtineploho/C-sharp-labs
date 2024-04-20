namespace DataBases.Models;

public interface IRepository<in T>
    where T : class
{
    Task<OperationResult> Create(T item);
}