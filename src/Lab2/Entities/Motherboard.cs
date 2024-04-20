using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class Motherboard : ComponentBase
{
    public Motherboard(
        string name,
        int ramSlots,
        int sataSlots,
        MotherboardFormFactor formFactor,
        string socket,
        Bios bios,
        WifiAdapter? wifiAdapter,
        DdrStandard ddrStandard,
        bool xmpCompatibility,
        IReadOnlyCollection<Jedec> memoryCompatibility,
        IReadOnlyCollection<PcieVersion> pciE)
        : base(name)
    {
        RamSlots = ramSlots <= 0
            ? throw new ArgumentOutOfRangeException(nameof(ramSlots))
            : ramSlots;
        SataSlots = sataSlots <= 0
            ? throw new ArgumentOutOfRangeException(nameof(sataSlots))
            : sataSlots;
        FormFactor = formFactor == MotherboardFormFactor.Unknown
            ? throw new ArgumentOutOfRangeException(nameof(formFactor))
            : formFactor;
        Socket = string.IsNullOrEmpty(socket) ? throw new ArgumentNullException(nameof(socket)) : socket;
        Bios = bios ?? throw new ArgumentOutOfRangeException(nameof(bios));
        WifiAdapter = wifiAdapter;
        DdrStandard = ddrStandard == DdrStandard.Unknown
            ? throw new ArgumentOutOfRangeException(nameof(ddrStandard))
            : ddrStandard;
        XmpCompatibility = xmpCompatibility;
        MemoryCompatibility = memoryCompatibility;
        if (pciE == null || pciE.Count == 0) throw new ArgumentNullException(nameof(pciE));
        PciE = pciE;
    }

    public int RamSlots { get; }
    public int SataSlots { get; }
    public MotherboardFormFactor FormFactor { get; }
    public string Socket { get; }
    public bool XmpCompatibility { get; set; }
    public IReadOnlyCollection<Jedec> MemoryCompatibility { get; set; }
    public Bios Bios { get; }
    public WifiAdapter? WifiAdapter { get; }
    public DdrStandard DdrStandard { get; }
    public IReadOnlyCollection<PcieVersion> PciE { get; }
}