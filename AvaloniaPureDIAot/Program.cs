using System;
using Avalonia;

namespace AvaloniaPureDIAot;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        var composition = new Composition();
        BuildAvaloniaApp(composition).StartWithClassicDesktopLifetime(args);
    }

    private static AppBuilder BuildAvaloniaApp(Composition composition) =>
        AppBuilder.Configure(() => new App(composition))
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
