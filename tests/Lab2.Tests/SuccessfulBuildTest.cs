using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class SuccessfulBuildTest
{
   [Theory]
   [MemberData(nameof(TestDataGenerator.SuccessfulBuildTestData), MemberType = typeof(TestDataGenerator))]
   public void TryToBuild(Computer computer)
   {
       var orderGenerator = new OrderGenerator(computer);

       Order order = orderGenerator.SendOrder();

       Assert.IsType<ComputerValidationResult.Success>(orderGenerator.Result);
       Assert.True(string.IsNullOrEmpty(order.Comment));
   }
}