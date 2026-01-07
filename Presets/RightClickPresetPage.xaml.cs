using System.Windows.Controls;
using System.Windows.Navigation;

namespace MinecraftAuto.Presets;

public partial class RightClickPresetPage : Page
{
    private readonly RightClickPreset _preset;

    public RightClickPresetPage(RightClickPreset preset)
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
