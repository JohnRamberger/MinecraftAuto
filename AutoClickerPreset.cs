namespace MinecraftAuto;

public class AutoClickerPreset
{
    public string Name { get; }
    public string Description { get; }
    public string KeyPattern { get; }

    private AutoClickerPreset(string name, string description, string keyPattern)
    {
        Name = name;
        Description = description;
        KeyPattern = keyPattern;
    }

    public static readonly AutoClickerPreset FastClick = new(
        "Fast Click (10 CPS)",
        "Clicks at a fast rate of 10 clicks per second.",
        "Left Mouse Button, 10 CPS"
    );

    public static readonly AutoClickerPreset UltraFast = new(
        "Ultra Fast (20 CPS)",
        "Clicks at an ultra-fast rate of 20 clicks per second.",
        "Left Mouse Button, 20 CPS"
    );

    public static readonly AutoClickerPreset Slow = new(
        "Slow (3 CPS)",
        "Clicks slowly at 3 clicks per second.",
        "Left Mouse Button, 3 CPS"
    );

    public static readonly AutoClickerPreset Custom = new(
        "Custom...",
        "Configure your own click speed and pattern.",
        "User-defined"
    );

    public static IReadOnlyList<AutoClickerPreset> All { get; } = new[]
    {
        FastClick, UltraFast, Slow, Custom
    };

    public override string ToString() => Name;
}
