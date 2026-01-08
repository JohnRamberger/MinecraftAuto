using MinecraftAuto.Presets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class ConcretePreset : AutoClickerPresetBase
{
    private bool done = false;

    public ConcretePreset(IntPtr hWnd) : base(
        hWnd,
        "Concrete",
        "Clicks left and right mouse button sequentially. Adjustable delays and offset.")
    {

    }

    public override void ApplySettings()
    {
        // Implement logic to apply both click settings
    }

    public override void Reset()
    {
        //var position = GetCursorPosition();

        //IntPtr lParam = (IntPtr)((position.Y << 16) | (position.X & 0xFFFF));

        //// Left up
        //SendMessage(TargetWindowHandle, NativeMethods.WM_LBUTTONUP, (IntPtr)1, lParam);

        //// Right up
        //SendMessage(TargetWindowHandle, NativeMethods.WM_RBUTTONUP, (IntPtr)1, lParam);

        //done = false;
    }

    public override async void Sequence()
    {
        //Debug.WriteLine($"done = {done}");
        //if (done)
        //{
        //    return;
        //}

        //var position = GetCursorPosition();

        //IntPtr lParam = (IntPtr)((position.Y << 16) | (position.X & 0xFFFF));

        //// Right down
        //SendMessage(TargetWindowHandle, NativeMethods.WM_RBUTTONDOWN, (IntPtr)1, lParam);

        //Task.Delay(500).Wait();

        //// Left down
        //SendMessage(TargetWindowHandle, NativeMethods.WM_LBUTTONDOWN, (IntPtr)1, lParam);

        //done = true;

        var position = GetCursorPosition();

        IntPtr lParam = (IntPtr)((position.Y << 16) | (position.X & 0xFFFF));

        SendMessage(TargetWindowHandle, NativeMethods.WM_RBUTTONDOWN, (IntPtr)1, lParam);
        SendMessage(TargetWindowHandle, NativeMethods.WM_RBUTTONUP, IntPtr.Zero, lParam);

        Task.Delay(50).Wait();

        SendMessage(TargetWindowHandle, NativeMethods.WM_LBUTTONDOWN, (IntPtr)1, lParam);

        Task.Delay(300).Wait();

        SendMessage(TargetWindowHandle, NativeMethods.WM_LBUTTONUP, IntPtr.Zero, lParam);
    }
}

