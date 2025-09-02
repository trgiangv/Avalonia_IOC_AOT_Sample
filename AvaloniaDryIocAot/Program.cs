using System;
using Avalonia;
using DryIoc;
using AvaloniaDryIocAot.Services;
using AvaloniaDryIocAot.ViewModels;
using AvaloniaDryIocAot.Views;

namespace AvaloniaDryIocAot;

internal static class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        var container = new Container(r => r
            .With(FactoryMethod.ConstructorWithResolvableArguments)
            .WithDefaultReuse(Reuse.Transient));

        // Explicit registrations (AOT-friendly)
        container.Register<ITimeService, TimeService>(Reuse.Singleton);
        container.Register<MainWindowViewModel>(Reuse.Transient);
        container.Register<MainWindow>(Reuse.Transient);

        BuildAvaloniaApp(container).StartWithClassicDesktopLifetime(args);
    }

    private static AppBuilder BuildAvaloniaApp(IContainer container) =>
        AppBuilder.Configure(() => new App(container))
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace();
}
