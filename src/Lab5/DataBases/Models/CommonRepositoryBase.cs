namespace DataBases.Models;

public abstract class CommonRepositoryBase<T> : ICommonRepository<T>
    where T : class
{
    protected CommonRepositoryBase(string connectionString)
    {
        ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    protected string ConnectionString { get; }

    public abstract Task<OperationResult> Create(T item);
    public abstract Task<OperationResult> Delete(string id);
    public abstract Task<OperationResult> Update(string id, T item);
    public abstract Task<T?> GetObject(string id);
    public abstract Task<IEnumerable<T>?> GetObjectsList();
}