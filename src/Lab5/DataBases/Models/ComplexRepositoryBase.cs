namespace DataBases.Models;

public abstract class ComplexRepositoryBase<T> : IComplexRepository<T>
    where T : class
{
    protected ComplexRepositoryBase(string connectionString)
    {
        ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    protected string ConnectionString { get; }

    public abstract Task<OperationResult> Create(T item);

    public abstract Task<OperationResult> DeleteAll(string id);

    public abstract Task<IEnumerable<T>?> GetObjectsList(string id);
}