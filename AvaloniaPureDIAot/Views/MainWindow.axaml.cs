using Avalonia.Controls;
using AvaloniaPureDIAot.ViewModels;

namespace AvaloniaPureDIAot.Views;

public partial class MainWindow : Window
{
    // Parameterless constructor for XAML/AOT compatibility
    public MainWindow() : this(null!)
    {
    }
    
    public MainWindow(MainWindowViewModel vm)
    {
        InitializeComponent();
        DataContext = vm;
    }
}
