using DebugMvvM.Models;

namespace DebugMvvM.Services;

/// <summary>
/// Interface for device communication service
/// </summary>
public interface IDeviceService
{
    /// <summary>
    /// Connect to device
    /// </summary>
    Task<bool> ConnectAsync(DeviceBase device);

    /// <summary>
    /// Disconnect from device
    /// </summary>
    Task DisconnectAsync(DeviceBase device);

    /// <summary>
    /// Read data from device
    /// </summary>
    Task<DeviceBase?> ReadDataAsync(DeviceBase device);

    /// <summary>
    /// Write data to device
    /// </summary>
    Task<bool> WriteDataAsync(DeviceBase device, object data);

    /// <summary>
    /// Check if device is connected
    /// </summary>
    bool IsConnected(DeviceBase device);
}
