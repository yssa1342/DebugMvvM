using DebugMvvM.Models;

namespace DebugMvvM.Services;

/// <summary>
/// Service for GJ750_4_60A device communication
/// </summary>
public class GJ750_4_60AService : IDeviceService
{
    public async Task<bool> ConnectAsync(DeviceBase device)
    {
        if (device is not GJ750_4_60ADevice gj750)
            return false;

        // TODO: Implement actual device connection logic
        // This is a placeholder implementation
        await Task.Delay(100); // Simulate connection delay
        
        gj750.IsConnected = true;
        gj750.LastCommunicationTime = DateTime.Now;
        
        return true;
    }

    public async Task DisconnectAsync(DeviceBase device)
    {
        if (device is not GJ750_4_60ADevice gj750)
            return;

        // TODO: Implement actual device disconnection logic
        await Task.Delay(50); // Simulate disconnection delay
        
        gj750.IsConnected = false;
    }

    public async Task<DeviceBase?> ReadDataAsync(DeviceBase device)
    {
        if (device is not GJ750_4_60ADevice gj750 || !gj750.IsConnected)
            return null;

        // TODO: Implement actual data reading logic
        // This is a placeholder implementation with simulated data
        await Task.Delay(50);

        gj750.Channel1Voltage = Random.Shared.NextDouble() * 60;
        gj750.Channel1Current = Random.Shared.NextDouble() * 60;
        gj750.Channel2Voltage = Random.Shared.NextDouble() * 60;
        gj750.Channel2Current = Random.Shared.NextDouble() * 60;
        gj750.Channel3Voltage = Random.Shared.NextDouble() * 60;
        gj750.Channel3Current = Random.Shared.NextDouble() * 60;
        gj750.Channel4Voltage = Random.Shared.NextDouble() * 60;
        gj750.Channel4Current = Random.Shared.NextDouble() * 60;
        
        gj750.TotalPower = (gj750.Channel1Voltage * gj750.Channel1Current) +
                           (gj750.Channel2Voltage * gj750.Channel2Current) +
                           (gj750.Channel3Voltage * gj750.Channel3Current) +
                           (gj750.Channel4Voltage * gj750.Channel4Current);
        
        gj750.Temperature = 25 + Random.Shared.NextDouble() * 10;
        gj750.LastCommunicationTime = DateTime.Now;

        return gj750;
    }

    public async Task<bool> WriteDataAsync(DeviceBase device, object data)
    {
        if (device is not GJ750_4_60ADevice gj750 || !gj750.IsConnected)
            return false;

        // TODO: Implement actual data writing logic
        await Task.Delay(50);
        
        gj750.LastCommunicationTime = DateTime.Now;
        return true;
    }

    public bool IsConnected(DeviceBase device)
    {
        return device is GJ750_4_60ADevice gj750 && gj750.IsConnected;
    }
}
