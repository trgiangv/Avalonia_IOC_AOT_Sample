using Avalonia.Controls;
using AvaloniaDryIocAot.ViewModels;

namespace AvaloniaDryIocAot.Views;

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
