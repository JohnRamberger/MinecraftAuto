using MinecraftAuto.Presets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class MouseClickPreset : AutoClickerPresetBase
{
    public double Delay1 { get; set; } // ms
    public double Delay2 { get; set; } // ms
    public double Offset { get; set; } // ms

    public MouseClickPreset(IntPtr hWnd) : base(
        hWnd,
        "Mouse Clicks",
        "Clicks left and right mouse button sequentially. Adjustable delays and offset.")
    {
        Delay1 = 50;
        Delay2 = 50;
        Offset = 10;
    }

    public override void ApplySettings()
    {
        // Implement logic to apply both click settings
    }

    public override async void Sequence()
    {
        var position = GetCursorPosition();

        IntPtr lParam = (IntPtr)((position.Y << 16) | (position.X & 0xFFFF));

        // Left click
        SendMessage(TargetWindowHandle, NativeMethods.WM_LBUTTONDOWN, (IntPtr)1, lParam);
        SendMessage(TargetWindowHandle, NativeMethods.WM_LBUTTONUP, IntPtr.Zero, lParam);


        // Wait for Delay1 + Offset
        await Task.Delay((int)(Delay1 + Offset)).ConfigureAwait(false);

        // Right click
        SendMessage(TargetWindowHandle, NativeMethods.WM_RBUTTONDOWN, (IntPtr)1, lParam);
        SendMessage(TargetWindowHandle, NativeMethods.WM_RBUTTONUP, IntPtr.Zero, lParam);

        // Wait for Delay2
        await Task.Delay((int)Delay2).ConfigureAwait(false);
    }

    public override void Reset()
    {

    }
}

