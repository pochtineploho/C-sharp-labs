namespace DataBases.Models;

public interface IComplexRepository<T> : IRepository<T>
    where T : class
{
    Task<OperationResult> DeleteAll(string id);
    Task<IEnumerable<T>?> GetObjectsList(string id);
}