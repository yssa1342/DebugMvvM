using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace DebugMvvM.ViewModels;

/// <summary>
/// Main window ViewModel
/// </summary>
public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ViewModelBase? _currentViewModel;

    [ObservableProperty]
    private Vdc32ViewModel _vdc32ViewModel;

    [ObservableProperty]
    private GJ750_4_60AViewModel _gj750ViewModel;

    public MainViewModel()
    {
        Title = "Device Monitor System";
        _vdc32ViewModel = new Vdc32ViewModel();
        _gj750ViewModel = new GJ750_4_60AViewModel();
        _currentViewModel = _vdc32ViewModel;
    }

    [RelayCommand]
    private void SwitchToVdc32()
    {
        CurrentViewModel = Vdc32ViewModel;
    }

    [RelayCommand]
    private void SwitchToGJ750()
    {
        CurrentViewModel = Gj750ViewModel;
    }

    partial void OnCurrentViewModelChanged(ViewModelBase? value)
    {
        // Can add logic when current view changes
    }
}
