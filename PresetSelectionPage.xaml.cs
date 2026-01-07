using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace MinecraftAuto;

public partial class PresetSelectionPage : Page
{
    private readonly Action _onUnbind;

    public PresetSelectionPage(Action onUnbind)
    {
        InitializeComponent();
        _onUnbind = onUnbind;

        // Example presets
        PresetComboBox.ItemsSource = new List<string>
        {
            "Fast Click (10 CPS)",
            "Ultra Fast (20 CPS)",
            "Slow (3 CPS)",
            "Custom..."
        };
        PresetComboBox.SelectedIndex = 0;
    }

    private void Unbind_Click(object sender, RoutedEventArgs e)
    {
        _onUnbind?.Invoke();
    }
}
