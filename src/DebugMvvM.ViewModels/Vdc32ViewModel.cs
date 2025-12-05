using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DebugMvvM.Models;
using DebugMvvM.Services;

namespace DebugMvvM.ViewModels;

/// <summary>
/// ViewModel for Vdc_32 device
/// </summary>
public partial class Vdc32ViewModel : ViewModelBase
{
    private readonly Vdc32Service _deviceService;
    
    [ObservableProperty]
    private Vdc32Device _device;

    [ObservableProperty]
    private bool _isConnected;

    [ObservableProperty]
    private string _connectionStatus = "Disconnected";

    public Vdc32ViewModel()
    {
        _deviceService = new Vdc32Service();
        _device = new Vdc32Device
        {
            DeviceId = "VDC32_001",
            DeviceName = "Vdc_32 Device"
        };
        Title = "Vdc_32 Device Monitor";
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
        if (result is Vdc32Device updatedDevice)
        {
            Device = updatedDevice;
        }
    }
}
