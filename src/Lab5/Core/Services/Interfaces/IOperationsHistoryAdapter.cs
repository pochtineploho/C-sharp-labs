using Core.Models;

namespace Core.Services.Interfaces;

public interface IOperationsHistoryAdapter
{
    Task<IEnumerable<Operation>> GetOperations(string bankAccount);

    Task<BinaryResult> AddOperation(string bankAccount, DateTime time, long amount);
}