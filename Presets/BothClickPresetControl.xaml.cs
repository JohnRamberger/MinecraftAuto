using System.Windows.Controls;

namespace MinecraftAuto.Presets;

public partial class BothClickPresetControl : UserControl
{
    public BothClickPresetControl(AutoClickerPresetBase preset)
    {
        InitializeComponent();
        DataContext = preset;
    }
}
