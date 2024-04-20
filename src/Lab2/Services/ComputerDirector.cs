using System;
using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class ComputerDirector
{
    public ComputerDirector(ComputerComponentsRepository repository)
    {
        Builder = new ComputerBuilder(repository);
        Repository = repository ?? throw new ArgumentNullException(nameof(repository));
    }

    private ComputerBuilder Builder { get; set; }
    private ComputerComponentsRepository Repository { get; set; }

    public ComputerDirector ChangeBuilder(ComputerBuilder computerBuilder)
    {
        Builder = computerBuilder ?? throw new ArgumentNullException(nameof(computerBuilder));

        return this;
    }

    public ComputerBuilder Direct(
        string cpu,
        string motherboard,
        string coolingFacility,
        IReadOnlyCollection<string> ramSticks,
        string computerCase,
        string powerSupply,
        string? gpu,
        string? wifiAdapter,
        IReadOnlyCollection<string>? ssds,
        IReadOnlyCollection<string>? hdds)
    {
        if (string.IsNullOrEmpty(cpu)) throw new ArgumentNullException(nameof(cpu));
        if (string.IsNullOrEmpty(motherboard)) throw new ArgumentNullException(nameof(motherboard));
        if (string.IsNullOrEmpty(coolingFacility)) throw new ArgumentNullException(nameof(coolingFacility));
        if (string.IsNullOrEmpty(computerCase)) throw new ArgumentNullException(nameof(computerCase));
        if (string.IsNullOrEmpty(powerSupply)) throw new ArgumentNullException(nameof(powerSupply));
        if (ramSticks is null) throw new ArgumentNullException(nameof(ramSticks));

        Builder.WithCpu(Repository.GetCpuByName(cpu))
            .WithMotherboard(Repository.GetMotherboardByName(motherboard))
            .WithCpuCoolingFacility(Repository.GetCpuCoolingFacilityByName(coolingFacility))
            .WithCase(Repository.GetCaseByName(computerCase))
            .WithPowerSupply(Repository.GetPowerSupplyByName(powerSupply));

        foreach (string ram in ramSticks)
        {
            Builder.AddRam(Repository.GetRamByName(ram));
        }

        if (wifiAdapter is not null) Builder.WithWifiAdapter(Repository.GetWifiAdapterByName(wifiAdapter));
        if (gpu is not null) Builder.WithGpu(Repository.GetGpuByName(gpu));
        if (ssds is not null)
        {
            foreach (string ssd in ssds)
            {
                Builder.AddSsd(Repository.GetSsdByName(ssd));
            }
        }

        if (hdds is not null)
        {
            foreach (string hdd in hdds)
            {
                Builder.AddHdd(Repository.GetHddByName(hdd));
            }
        }

        return Builder;
    }
}