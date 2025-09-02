using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using DryIoc;
using AvaloniaDryIocAot.Views;

namespace AvaloniaDryIocAot;

public partial class App : Application
{
    private readonly IContainer _container;
    
    // Parameterless constructor for XAML/AOT compatibility
    public App() : this(null!)
    {
    }
    
    public App(IContainer container) => _container = container;

    public override void Initialize() => AvaloniaXamlLoader.Load(this);

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = _container.Resolve<MainWindow>();
        }
        base.OnFrameworkInitializationCompleted();
    }
}
