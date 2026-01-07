using System;
using System.Windows.Controls;

namespace MinecraftAuto;

public partial class BindingPage : Page
{
    private readonly Action<IntPtr, string, uint> _onBound;

    public BindingPage(Action<IntPtr, string, uint> onBound)
    {
        InitializeComponent();
        _onBound = onBound;
        // The actual binding is handled in MainWindow via hotkey
    }
}
