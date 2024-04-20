using Core.Models;
using Core.Services.Interfaces;

namespace Core.Services;

public class GetHistoryService : IGetHistoryService
{
    private readonly IOperationsHistoryAdapter _adapter;

    public GetHistoryService(IOperationsHistoryAdapter adapter)
    {
        _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
    }

    public async Task<IEnumerable<Operation>> GetHistory(string bankAccountNumber)
    {
        return await _adapter.GetOperations(bankAccountNumber);
    }
}