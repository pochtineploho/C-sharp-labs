#pragma warning disable CA1305
using System.Threading.Tasks;
using Core.Models;
using Core.Services;
using Core.Services.Adapters;
using DataBases.Entities.Repositories;
using DataBases.Models;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class CashOutFailTest
{
    [Theory]
    [MemberData(nameof(Lab5TestDataGenerator.CashOutFailTestData), MemberType = typeof(Lab5TestDataGenerator))]
    public async Task TestBadCashOut(long balance, long deposit)
    {
        {
            BankRepository? bankRepository = Substitute.For<BankRepository>(string.Empty);
            HistoryRepository? historyRepository = Substitute.For<HistoryRepository>(string.Empty);
            var service = new BalanceService(new BankAccountAdapter(bankRepository), new OperationHistoryAdapter(historyRepository));

            historyRepository.Create(Arg.Any<HistoryUnit>()).Returns(new OperationResult.Success("Success"));
            var unit = new BankUnit("6969152203847379", "1324", balance);
            bankRepository.GetObject("6969152203847379").Returns(unit);

            bankRepository.Update("6969152203847379", Arg.Is<BankUnit>(x => x.Budget == balance - deposit))
                .Returns(new OperationResult.Success((balance - deposit).ToString()));
            BinaryResult result = await service.CashOut("6969152203847379", deposit);

            Assert.NotEqual((balance - deposit).ToString(), result.Message);
        }
    }
}