using Itmo.ObjectOrientedProgramming.Lab3.Models;

namespace Itmo.ObjectOrientedProgramming.Lab3.Services.Builders;

public interface IAddresseeLoggerProxyBuilder
{
    public AddresseeFilterProxyBuilder WithLogger(ILogger logger);
}