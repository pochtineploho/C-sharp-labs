namespace DataBases.Models;

public interface ICommonRepository<T> : IRepository<T>
    where T : class
{
    Task<OperationResult> Update(string id, T item);
    Task<OperationResult> Delete(string id);
    Task<T?> GetObject(string id);
    Task<IEnumerable<T>?> GetObjectsList();
}