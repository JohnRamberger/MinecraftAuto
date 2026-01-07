namespace MinecraftAuto;

// Base class for all presets
public abstract class AutoClickerPresetBase
{
    public string Name { get; }
    public string Description { get; }

    protected AutoClickerPresetBase(string name, string description)
    {
        Name = name;
        Description = description;
    }

    public abstract void ApplySettings();
    public override string ToString() => Name;
}

// Left Click preset
public class LeftClickPreset : AutoClickerPresetBase
{
    public double Delay { get; set; } // ms

    public LeftClickPreset() : base(
        "Left Click",
        "Clicks the left mouse button. Adjustable delay.")
    {
        Delay = 50;
    }

    public override void ApplySettings()
    {
        // Implement logic to apply left click settings
    }
}

// Right Click preset
public class RightClickPreset : AutoClickerPresetBase
{
    public double Delay { get; set; } // ms

    public RightClickPreset() : base(
        "Right Click",
        "Clicks the right mouse button. Adjustable delay.")
    {
        Delay = 50;
    }

    public override void ApplySettings()
    {
        // Implement logic to apply right click settings
    }
}

// Both (Sequential) preset
public class BothClickPreset : AutoClickerPresetBase
{
    public double Delay1 { get; set; } // ms
    public double Delay2 { get; set; } // ms
    public double Offset { get; set; } // ms

    public BothClickPreset() : base(
        "Both (Sequential)",
        "Clicks left then right mouse button sequentially. Adjustable delays and offset.")
    {
        Delay1 = 50;
        Delay2 = 50;
        Offset = 10;
    }

    public override void ApplySettings()
    {
        // Implement logic to apply both click settings
    }
}

// Registry of all presets
public static class AutoClickerPresets
{
    public static readonly LeftClickPreset LeftClick = new();
    public static readonly RightClickPreset RightClick = new();
    public static readonly BothClickPreset BothSequential = new();

    public static IReadOnlyList<AutoClickerPresetBase> All { get; } = new AutoClickerPresetBase[]
    {
        LeftClick, RightClick, BothSequential
    };
}
