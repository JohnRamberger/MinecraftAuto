using System.Windows.Controls;
using System.Windows.Navigation;

namespace MinecraftAuto.Presets;

public partial class ConcretePresetPage : Page
{
    private readonly ConcretePreset _preset;

    public ConcretePresetPage(ConcretePreset preset)
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
