using System.Windows.Controls;

namespace MinecraftAuto.Presets;

public partial class ConcretePresetControl : UserControl
{
    public ConcretePresetControl(AutoClickerPresetBase preset)
    {
        InitializeComponent();
        DataContext = preset;
    }
}
