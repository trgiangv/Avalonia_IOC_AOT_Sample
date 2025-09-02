using Pure.DI;
using AvaloniaPureDIAot.Services;
using AvaloniaPureDIAot.ViewModels;
using AvaloniaPureDIAot.Views;

namespace AvaloniaPureDIAot;

// This partial class will be completed by Pure.DI source generator at compile-time.
public partial class Composition
{
    private void Setup() => DI.Setup(nameof(Composition))
      .Bind<ITimeService>().To<TimeService>()
      .Bind<MainWindowViewModel>().To<MainWindowViewModel>()
      .Bind<MainWindow>().To<MainWindow>()
      .Root<MainWindow>("BuildMainWindow");
}
