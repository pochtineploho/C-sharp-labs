using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Models;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services;

public class MotherboardBuilder : IBuilder<Motherboard>
{
    public MotherboardBuilder()
    {
        Name = string.Empty;
        RamSlots = 0;
        SataSlots = 0;
        FormFactor = MotherboardFormFactor.Unknown;
        Socket = string.Empty;
        XmpCompatibility = false;
        MemoryCompatibility = new List<Jedec>();
        Bios = null;
        WifiAdapter = null;
        DdrStandard = DdrStandard.Unknown;
        PciE = new List<PcieVersion>();
    }

    private string Name { get; set; }
    private int RamSlots { get; set; }
    private int SataSlots { get; set; }
    private MotherboardFormFactor FormFactor { get; set; }
    private string Socket { get; set; }
    private bool XmpCompatibility { get; set; }
    private List<Jedec> MemoryCompatibility { get; set; }
    private Bios? Bios { get; set; }
    private WifiAdapter? WifiAdapter { get; set; }
    private DdrStandard DdrStandard { get; set; }
    private List<PcieVersion> PciE { get; set; }

    public void Reset()
    {
        Name = string.Empty;
        RamSlots = 0;
        SataSlots = 0;
        FormFactor = MotherboardFormFactor.Unknown;
        Socket = string.Empty;
        XmpCompatibility = false;
        MemoryCompatibility = new List<Jedec>();
        Bios = null;
        WifiAdapter = null;
        DdrStandard = DdrStandard.Unknown;
        PciE = new List<PcieVersion>();
    }

    public MotherboardBuilder WithName(string name)
    {
        Name = string.IsNullOrEmpty(name) ? throw new ArgumentNullException(nameof(name)) : name;

        return this;
    }

    public MotherboardBuilder WithRamSlots(int ramSlots)
    {
        RamSlots = ramSlots <= 0 ? throw new ArgumentOutOfRangeException(nameof(ramSlots)) : ramSlots;

        return this;
    }

    public MotherboardBuilder WithSataSlots(int sataSlots)
    {
        SataSlots = sataSlots <= 0 ? throw new ArgumentOutOfRangeException(nameof(sataSlots)) : sataSlots;

        return this;
    }

    public MotherboardBuilder WithSocket(string socket)
    {
        Socket = string.IsNullOrEmpty(socket) ? throw new ArgumentNullException(nameof(socket)) : socket;

        return this;
    }

    public MotherboardBuilder WithXmpCompatibility()
    {
        XmpCompatibility = true;

        return this;
    }

    public MotherboardBuilder WithFormFactor(MotherboardFormFactor formFactor)
    {
        FormFactor = formFactor == MotherboardFormFactor.Unknown
            ? throw new ArgumentOutOfRangeException(nameof(formFactor))
            : formFactor;

        return this;
    }

    public MotherboardBuilder WithBios(Bios bios)
    {
        Bios = bios ?? throw new ArgumentOutOfRangeException(nameof(bios));

        return this;
    }

    public MotherboardBuilder WithWifiAdapter(WifiAdapter? wifiAdapter)
    {
        WifiAdapter = wifiAdapter;

        return this;
    }

    public MotherboardBuilder WithDdrStandard(DdrStandard ddrStandard)
    {
        DdrStandard = ddrStandard == DdrStandard.Unknown
            ? throw new ArgumentOutOfRangeException(nameof(ddrStandard))
            : ddrStandard;

        return this;
    }

    public MotherboardBuilder AddSupportedPciE(PcieVersion pciE, int quantity = 1)
    {
        if (quantity <= 0) throw new ArgumentOutOfRangeException(nameof(quantity));
        for (int i = 0; i < quantity; i++)
        {
            PciE.Add(pciE);
        }

        return this;
    }

    public MotherboardBuilder AddSupportedPciE(IReadOnlyCollection<PcieVersion> pciEs)
    {
        if (pciEs is null) throw new ArgumentNullException(nameof(pciEs));
        foreach (PcieVersion pciE in pciEs)
            PciE.Add(pciE);

        return this;
    }

    public MotherboardBuilder WithSupportedPciEs(IReadOnlyCollection<PcieVersion> pciEs)
    {
        PciE = new List<PcieVersion>(pciEs);

        return this;
    }

    public MotherboardBuilder AddMemoryCompatibility(Jedec jedec)
    {
        MemoryCompatibility.Add(jedec);

        return this;
    }

    public MotherboardBuilder WithMemoryCompatibility(IReadOnlyCollection<Jedec> jedecs)
    {
        MemoryCompatibility = new List<Jedec>(jedecs);

        return this;
    }

    public MotherboardBuilder AddMemoryCompatibility(IReadOnlyCollection<Jedec> jedecs)
    {
        if (jedecs is null) throw new ArgumentNullException(nameof(jedecs));
        foreach (Jedec jedec in jedecs)
            MemoryCompatibility.Add(jedec);

        return this;
    }

    public Motherboard GetResult()
    {
        if (Bios is null) throw new ArgumentNullException(nameof(Bios));
        return new Motherboard(
            Name,
            RamSlots,
            SataSlots,
            FormFactor,
            Socket,
            Bios,
            WifiAdapter,
            DdrStandard,
            XmpCompatibility,
            MemoryCompatibility,
            PciE);
    }
}