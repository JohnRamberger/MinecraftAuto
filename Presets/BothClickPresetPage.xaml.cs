using System.Windows.Controls;
using System.Windows.Navigation;

namespace MinecraftAuto.Presets;

public partial class BothClickPresetPage : Page
{
    private readonly BothClickPreset _preset;

    public BothClickPresetPage(BothClickPreset preset)
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
