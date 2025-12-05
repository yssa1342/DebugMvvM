using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DebugMvvM.Models;
using DebugMvvM.Services;

namespace DebugMvvM.ViewModels;

/// <summary>
/// ViewModel for GJ750_4_60A device
/// </summary>
public partial class GJ750_4_60AViewModel : ViewModelBase
{
    private readonly GJ750_4_60AService _deviceService;
    
    [ObservableProperty]
    private GJ750_4_60ADevice _device;

    [ObservableProperty]
    private bool _isConnected;

    [ObservableProperty]
    private string _connectionStatus = "Disconnected";

    public GJ750_4_60AViewModel()
    {
        _deviceService = new GJ750_4_60AService();
        _device = new GJ750_4_60ADevice
        {
            DeviceId = "GJ750_001",
            DeviceName = "GJ750_4_60A Device"
        };
        Title = "GJ750_4_60A Device Monitor";
    }

    [RelayCommand]
    private async Task ConnectAsync()
    {
        var result = await _deviceService.ConnectAsync(Device);
        IsConnected = result;
        ConnectionStatus = result ? "Connected" : "Connection Failed";
        
        if (result)
        {
            // Start periodic data reading
            _ = Task.Run(async () =>
            {
                while (IsConnected)
                {
                    await ReadDataAsync();
                    await Task.Delay(1000); // Update every second
                }
            });
        }
    }

    [RelayCommand]
    private async Task DisconnectAsync()
    {
        await _deviceService.DisconnectAsync(Device);
        IsConnected = false;
        ConnectionStatus = "Disconnected";
    }

    [RelayCommand]
    private async Task ReadDataAsync()
    {
        var result = await _deviceService.ReadDataAsync(Device);
        if (result is GJ750_4_60ADevice updatedDevice)
        {
            Device = updatedDevice;
        }
    }
}
