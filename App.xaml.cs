using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MinecraftAuto;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static ILoggerFactory LoggerFactory { get; private set; }
    public static ILogger Logger { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(builder =>
        {
            builder
                .AddDebug()
                .SetMinimumLevel(LogLevel.Information);
        });
        Logger = LoggerFactory.CreateLogger("MinecraftAuto");

        base.OnStartup(e);
    }
}

