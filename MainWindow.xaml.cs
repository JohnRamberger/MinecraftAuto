using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MinecraftAuto;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private const int HOTKEY_ID = 9000;
    private const uint MOD_NONE = 0x0000;
    private const uint VK_F8 = 0x77;

    [DllImport("user32.dll")]
    private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

    [DllImport("user32.dll")]
    private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

    [DllImport("user32.dll")]
    private static extern IntPtr GetForegroundWindow();

    [DllImport("user32.dll")]
    private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

    private readonly ILogger _logger;
    private IntPtr? _boundWindow = null;

    public MainWindow()
    {
        InitializeComponent();
        _logger = App.Logger;

        Loaded += (s, e) =>
        {
            var helper = new WindowInteropHelper(this);
            RegisterHotKey(helper.Handle, HOTKEY_ID, MOD_NONE, VK_F8);
            HwndSource.FromHwnd(helper.Handle).AddHook(HwndHook);

            // Navigate to the binding page on startup
            MainFrame.Navigate(new BindingPage(OnBoundToWindow));
        };
        Closed += (s, e) =>
        {
            var helper = new WindowInteropHelper(this);
            UnregisterHotKey(helper.Handle, HOTKEY_ID);
        };
    }

    // Callback to navigate to preset selection page
    private void OnBoundToWindow(IntPtr windowHandle, string windowTitle, uint pid)
    {
        _boundWindow = windowHandle;
        MainFrame.Navigate(new PresetSelectionPage(OnUnbind));
    }

    // Callback to unbind and return to binding page
    private void OnUnbind()
    {
        _boundWindow = null;
        MainFrame.Navigate(new BindingPage(OnBoundToWindow));
    }

    private IntPtr HwndHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        const int WM_HOTKEY = 0x0312;
        if (msg == WM_HOTKEY && wParam.ToInt32() == HOTKEY_ID)
        {
            IntPtr fgWindow = GetForegroundWindow();
            GetWindowThreadProcessId(fgWindow, out uint pid);
            var proc = Process.GetProcessById((int)pid);
            _logger.LogInformation("Bound to window: {Title} (PID: {Pid})", proc.MainWindowTitle, pid);
            MessageBox.Show($"Bound to window: {proc.MainWindowTitle} (PID: {pid})");
            // Store fgWindow as your target handle here

            // Navigate to preset selection page
            Dispatcher.Invoke(() =>
            {
                OnBoundToWindow(fgWindow, proc.MainWindowTitle, pid);
            });

            handled = true;
        }
        return IntPtr.Zero;
    }
}