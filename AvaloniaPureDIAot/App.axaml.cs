using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;

namespace AvaloniaPureDIAot;

public partial class App : Application
{
    private readonly Composition _composition;
    
    // Parameterless constructor for XAML/AOT compatibility
    public App() : this(null!)
    {
    }
    
    public App(Composition composition) => _composition = composition;

    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = _composition.BuildMainWindow;
        }
        base.OnFrameworkInitializationCompleted();
    }
}
