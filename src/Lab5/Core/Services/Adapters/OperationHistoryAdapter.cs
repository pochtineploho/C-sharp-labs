using Core.Exceptions;
using Core.Models;
using Core.Services.Interfaces;
using DataBases.Entities.Repositories;
using DataBases.Models;

namespace Core.Services.Adapters;

public class OperationHistoryAdapter : IOperationsHistoryAdapter
{
    private readonly HistoryRepository _historyRepository;

    public OperationHistoryAdapter(HistoryRepository historyRepository)
    {
        _historyRepository = historyRepository ?? throw new ArgumentNullException(nameof(historyRepository));
    }

    public async Task<IEnumerable<Operation>> GetOperations(string bankAccount)
    {
        if (_historyRepository is null) throw new DataBaseIsNotConnectedException();

        IEnumerable<HistoryUnit> units = await _historyRepository.GetObjectsList(bankAccount) ??
                                        throw new DataBaseErrorException("Cant find user in data base");

        var operations = new List<Operation>();
        operations.AddRange(units.Select(unit => new Operation(unit.BankAccount, unit.Amount, unit.DateTime)));

        return operations;
    }

    public async Task<BinaryResult> AddOperation(string bankAccount, DateTime time, long amount)
    {
        if (_historyRepository is null) throw new DataBaseIsNotConnectedException();

        OperationResult result = await _historyRepository.Create(new HistoryUnit(bankAccount, amount, time)) ??
                                 throw new DataBaseIsNotConnectedException();

        return result is OperationResult.Success
            ? new BinaryResult.Success(result.Message)
            : new BinaryResult.Fail(result.Message);
    }
}