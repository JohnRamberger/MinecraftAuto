using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Extensions.Logging;
using MinecraftAuto.Presets;

namespace MinecraftAuto;

public partial class PresetSelectionPage : Page
{
    private readonly Action _onUnbind;
    private bool _isAutoRunning = false;

    public bool IsAutoRunning => _isAutoRunning;

    private readonly ILogger _logger;

    private CancellationTokenSource? _cancellationTokenSource;

    private IntPtr targetWindowHandle;

    public PresetSelectionPage(Action onUnbind, string windowTitle, uint pid, IntPtr windowHandle)
    {
        InitializeComponent();
        _logger = App.Logger;
        _onUnbind = onUnbind;
        targetWindowHandle = windowHandle;


        MouseClickPreset mouseClickPreset = new(windowHandle);
        ConcretePreset concretePreset = new(windowHandle);

        PresetComboBox.ItemsSource = new List<AutoClickerPresetBase>
        {
            concretePreset,
            mouseClickPreset
        };

        PresetComboBox.SelectedIndex = 0;

        BoundMessageTextBlock.Text = $"Bound to window: {windowTitle} (PID: {pid})";

        Loaded += PresetSelectionPage_Loaded;
        Unloaded += PresetSelectionPage_Unloaded;
    }

    private void PresetSelectionPage_Loaded(object sender, RoutedEventArgs e)
    {
        // Register keybinds
        Window.GetWindow(this).PreviewKeyDown += PresetSelectionPage_PreviewKeyDown;
    }

    private void PresetSelectionPage_Unloaded(object sender, RoutedEventArgs e)
    {
        var window = Window.GetWindow(this);
        if (window != null)
        {
            window.PreviewKeyDown -= PresetSelectionPage_PreviewKeyDown;
        }
    }

    private void PresetSelectionPage_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        // F9 toggles auto-clicker only
        if (e.Key == Key.F9)
        {
            if (_isAutoRunning)
                StopAuto();
            else
                StartAuto();
            e.Handled = true;
        }
        // No binding logic here; handled in MainWindow
    }

    private void PresetComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Always stop auto when swapping presets
        if (_isAutoRunning)
            StopAuto();

        var selected = PresetComboBox.SelectedItem;
        if (selected is AutoClickerPresetBase preset)
        {
            if (preset.Name.Contains("Mouse Clicks", StringComparison.OrdinalIgnoreCase))
                PresetSettingsHost.Content = new MouseClickPresetControl(preset);
            else if (preset.Name.Contains("Concrete", StringComparison.OrdinalIgnoreCase))
                PresetSettingsHost.Content = new ConcretePresetControl(preset);
            else
                PresetSettingsHost.Content = null;
        }
        else
        {
            PresetSettingsHost.Content = null;
        }
    }

    private void StartStopButton_Click(object sender, RoutedEventArgs e)
    {
        if (_isAutoRunning)
            StopAuto();
        else
            StartAuto();
    }

    public void StartAuto()
    {
        if (_isAutoRunning) return;
        _isAutoRunning = true;
        StartStopButton.Content = "Stop";
        _logger.LogInformation("Auto-clicker started.");


        // Start!!
        if (_cancellationTokenSource is not null)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }
        _cancellationTokenSource = new CancellationTokenSource();

        var selected = PresetComboBox.SelectedItem as AutoClickerPresetBase;

        Task.Run(async () =>
        {
            while (_cancellationTokenSource is not null && !_cancellationTokenSource.Token.IsCancellationRequested)
            {
                try
                {
                    selected?.Sequence();
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error during auto-clicking sequence.");
                    StopAuto();
                }
            }
        });
    }

    public void StopAuto()
    {
        if (!_isAutoRunning) return;
        _isAutoRunning = false;
        StartStopButton.Content = "Start";
        _logger.LogInformation("Auto-clicker stopped.");


        // Stop!!
        if (_cancellationTokenSource is not null)
        {
            _cancellationTokenSource.Cancel();
            _cancellationTokenSource.Dispose();
            _cancellationTokenSource = null;
        }

        var selected = PresetComboBox.SelectedItem as AutoClickerPresetBase;
        selected?.Reset();
    }

    private void Unbind_Click(object sender, RoutedEventArgs e)
    {
        _onUnbind?.Invoke();
    }
}
