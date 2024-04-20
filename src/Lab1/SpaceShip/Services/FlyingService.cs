using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Results.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShip.Services;

public class FlyingService
{
    private readonly FuelMarket.Models.FuelMarket _fuelMarket = new();
    private Results.Models.Results _results = new(new TimeFuel(), ResultCases.Success);
    private BestResult _bestPriceResult = new(double.MaxValue, double.MaxValue, null);
    private BestResult _bestTimeResult = new(double.MaxValue, double.MaxValue, null);

    public FinalResult CompareShips(
        IReadOnlyCollection<Entities.SpaceShip> spaceShips,
        IReadOnlyCollection<EnvironmentBase> environments)
    {
        if (environments is null) throw new ArgumentNullException(nameof(environments));
        if (spaceShips is null) throw new ArgumentNullException(nameof(spaceShips));

        foreach (Entities.SpaceShip spaceShip in spaceShips)
        {
            if (spaceShip == null) throw new ArgumentNullException(nameof(spaceShips));
            CheckTheRoute(spaceShip, environments);
            if (_results.Result != ResultCases.Success) continue;
            double price =
                _fuelMarket.CountCost(_results.TimeAndFuel.ActivePlasma, _results.TimeAndFuel.GravitonMatter);
            if (_results.TimeAndFuel.Time < _bestTimeResult.Time)
            {
                _bestTimeResult = new BestResult(
                    _results.TimeAndFuel.Time,
                    price,
                    spaceShip);
            }

            if (price < _bestPriceResult.Price)
            {
                _bestPriceResult = new BestResult(
                    _results.TimeAndFuel.Time,
                    price,
                    spaceShip);
            }

            _results = new Results.Models.Results(new TimeFuel(), ResultCases.Success);
        }

        return new FinalResult(
            _bestTimeResult.SpaceShip is null ? null : _bestTimeResult,
            _bestPriceResult.SpaceShip is null ? null : _bestPriceResult);
    }

    public Results.Models.Results CheckTheRoute(
        Entities.SpaceShip spaceShip,
        IReadOnlyCollection<EnvironmentBase> environments)
    {
        if (environments is null) throw new ArgumentNullException(nameof(environments));
        if (spaceShip is null) throw new ArgumentNullException(nameof(spaceShip));
        foreach (EnvironmentBase environment in environments)
        {
            if (environment is null) throw new ArgumentNullException(nameof(environments));
            Results.Models.Results result = TryToFly(spaceShip, environment);
            if (result.Result != ResultCases.Success)
            {
                _results = result;
                return _results;
            }

            _results.TimeAndFuel.Add(result.TimeAndFuel);
        }

        return _results;
    }

    public Results.Models.Results CheckTheRoute(
        Entities.SpaceShip spaceShip,
        EnvironmentBase environment) => CheckTheRoute(spaceShip, environments: new[] { environment });

    private static Results.Models.Results TryToFly(Entities.SpaceShip spaceShip, EnvironmentBase environment)
    {
        Results.Models.Results result = environment.CountFuelAndTime(spaceShip);
        if (result.Result == ResultCases.ShipLost) return result;
        foreach (ObstacleBase obstacle in environment.Obstacles)
        {
            obstacle.DealDamage(spaceShip);
            if (!spaceShip.CrewIsAlive) return new Results.Models.Results(new TimeFuel(), ResultCases.CrewDead);
            if (!spaceShip.IsIntact) return new Results.Models.Results(new TimeFuel(), ResultCases.ShipDestroyed);
        }

        return result;
    }
}