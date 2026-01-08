using System.Windows.Controls;
using System.Windows.Navigation;

namespace MinecraftAuto.Presets;

public partial class MouseClickPresetPage : Page
{
    private readonly MouseClickPreset _preset;

    public MouseClickPresetPage(MouseClickPreset preset)
    {
        InitializeComponent();
        _preset = preset;
        DataContext = _preset;
    }

    private void ApplyButton_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        _preset.ApplySettings();
        NavigationService?.GoBack();
    }
}
