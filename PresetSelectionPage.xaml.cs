using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace MinecraftAuto;

public partial class PresetSelectionPage : Page
{
    private readonly Action _onUnbind;

    public PresetSelectionPage(Action onUnbind, string windowTitle, uint pid)
    {
        InitializeComponent();
        _onUnbind = onUnbind;

        // Use the new class for presets
        PresetComboBox.ItemsSource = AutoClickerPreset.All;
        PresetComboBox.SelectedIndex = 0;

        BoundMessageTextBlock.Text = $"Bound to window: {windowTitle} (PID: {pid})";
    }

    private void Unbind_Click(object sender, RoutedEventArgs e)
    {
        _onUnbind?.Invoke();
    }
}
