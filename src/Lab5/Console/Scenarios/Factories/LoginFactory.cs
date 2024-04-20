using Console.Models;
using Core.Exceptions;
using Core.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class LoginFactory : ScenarioFactoryBase
{
    public LoginFactory(SuperFacade service)
        : base(service)
    { }

    public override IScenario Create()
    {
        return Service.GetCurrentUserRole() switch
        {
            Role.Admin => new AdminLoginScenario(Service),
            Role.User => new UserLoginScenario(Service),
            null => throw new NoCurrentUserException(),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}