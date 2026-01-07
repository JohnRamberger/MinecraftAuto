using System.Windows.Controls;

namespace MinecraftAuto.Presets;

public partial class RightClickPresetControl : UserControl
{
    public RightClickPresetControl(AutoClickerPresetBase preset)
    {
        InitializeComponent();
        DataContext = preset;
    }
}
