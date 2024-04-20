using Console.Models;
using Core.Models;
using Core.Services;

namespace Console.Scenarios.Factories;

public class ChooseActionFactory : ScenarioFactoryBase
{
    private readonly IEnumerable<string> _possibleUserScenarios;
    private readonly IEnumerable<string> _possibleAdminScenarios;

    public ChooseActionFactory(
        SuperFacade service,
        IEnumerable<string> possibleUserScenarios,
        IEnumerable<string> possibleAdminScenarios)
        : base(service)
    {
        _possibleUserScenarios =
            possibleUserScenarios ?? throw new ArgumentNullException(nameof(possibleUserScenarios));
        _possibleAdminScenarios =
            possibleAdminScenarios ?? throw new ArgumentNullException(nameof(possibleAdminScenarios));
    }

    public override IScenario Create()
    {
        return Service.GetCurrentUserRole() switch
        {
            Role.Admin => new ChooseActionScenario(Service, _possibleAdminScenarios),
            Role.User => new ChooseActionScenario(Service, _possibleUserScenarios),
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}