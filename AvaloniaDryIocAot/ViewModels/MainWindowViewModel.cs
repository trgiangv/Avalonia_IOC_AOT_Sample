using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using AvaloniaDryIocAot.Services;

namespace AvaloniaDryIocAot.ViewModels;

public sealed partial class MainWindowViewModel : ObservableObject
{
    private readonly ITimeService _time;
    
    [ObservableProperty]
    private string _now;

    public MainWindowViewModel(ITimeService time)
    {
        _time = time;
        _now = _time.NowString();
    }

    [RelayCommand]
    private void Refresh()
    {
        Now = _time.NowString();
    }
}
