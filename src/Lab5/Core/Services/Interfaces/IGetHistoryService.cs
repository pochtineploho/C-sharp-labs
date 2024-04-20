using Core.Models;

namespace Core.Services.Interfaces;

public interface IGetHistoryService
{
    Task<IEnumerable<Operation>> GetHistory(string bankAccountNumber);
}