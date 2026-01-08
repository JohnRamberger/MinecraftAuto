// ...existing code...
using System.Runtime.InteropServices;

public class Clicker
{
    private IntPtr targetWindowHandle = IntPtr.Zero; // Updated to accept external handle
    private bool isClicking = false;
    private int clickIntervalMs = 1000;
    private CancellationTokenSource? cancellationTokenSource;

    public void SetTargetWindowHandle(IntPtr windowHandle)
    {
        targetWindowHandle = windowHandle;
    }

    public void SetInterval(int milliseconds)
    {
        clickIntervalMs = Math.Max(1, milliseconds);
    }

    public void StartClicking()
    {
        if (isClicking || targetWindowHandle == IntPtr.Zero) return; // Ensure handle is set

        cancellationTokenSource = new CancellationTokenSource();
        var token = cancellationTokenSource.Token;
        isClicking = true;

        Task.Run(async () =>
        {
            while (!token.IsCancellationRequested)
            {
                PerformClick();
                await Task.Delay(clickIntervalMs, token);
            }
        });
    }

    public void StopClicking()
    {
        cancellationTokenSource?.Cancel();
        cancellationTokenSource = null;
        isClicking = false;
    }

    private void PerformClick()
    {
        if (targetWindowHandle == IntPtr.Zero) return; // Ensure handle is valid

        // Simulate a left mouse click
        mouse_event(MouseEventFlags.LEFTDOWN, 0, 0, 0, 0);
        mouse_event(MouseEventFlags.LEFTUP, 0, 0, 0, 0);
    }

    [DllImport("user32.dll", SetLastError = true)]
    private static extern void mouse_event(MouseEventFlags dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

    [Flags]
    private enum MouseEventFlags : uint
    {
        LEFTDOWN = 0x0002,
        LEFTUP = 0x0004
    }
}
// ...existing code...
