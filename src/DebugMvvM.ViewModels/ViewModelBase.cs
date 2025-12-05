using CommunityToolkit.Mvvm.ComponentModel;

namespace DebugMvvM.ViewModels;

/// <summary>
/// Base class for all ViewModels
/// </summary>
public abstract class ViewModelBase : ObservableObject
{
    private string _title = string.Empty;
    
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }
}
