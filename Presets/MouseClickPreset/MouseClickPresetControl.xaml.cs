using System.Windows.Controls;

namespace MinecraftAuto.Presets;

public partial class MouseClickPresetControl : UserControl
{
    public MouseClickPresetControl(AutoClickerPresetBase preset)
    {
        InitializeComponent();
        DataContext = preset;
    }
}
