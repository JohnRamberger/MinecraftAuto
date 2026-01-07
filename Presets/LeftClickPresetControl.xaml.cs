using System.Windows.Controls;

namespace MinecraftAuto.Presets;

public partial class LeftClickPresetControl : UserControl
{
    public LeftClickPresetControl(AutoClickerPresetBase preset)
    {
        InitializeComponent();
        DataContext = preset;
    }
}
