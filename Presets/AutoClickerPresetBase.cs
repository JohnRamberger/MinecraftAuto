using System.Drawing;
using System.Runtime.InteropServices;

namespace MinecraftAuto.Presets;

// Base class for all presets
public abstract class AutoClickerPresetBase
{
    public string Name { get; }
    public string Description { get; }

    protected IntPtr TargetWindowHandle = IntPtr.Zero;

    protected AutoClickerPresetBase(IntPtr hWnd, string name, string description)
    {
        TargetWindowHandle = hWnd;
        Name = name;
        Description = description;
    }

    public abstract void ApplySettings();
    public abstract void Reset();


    public override string ToString() => Name;

    public abstract void Sequence();

    [DllImport("user32.dll")]
    protected static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

    protected Point GetCursorPosition()
    {
        NativeMethods.POINT p;
        NativeMethods.GetCursorPos(out p);
        return new Point(p.X, p.Y);
    }
}
