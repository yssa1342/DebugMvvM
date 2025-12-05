namespace DebugMvvM.Models;

/// <summary>
/// Base class for all device models
/// </summary>
public abstract class DeviceBase
{
    /// <summary>
    /// Device unique identifier
    /// </summary>
    public string DeviceId { get; set; } = string.Empty;

    /// <summary>
    /// Device name
    /// </summary>
    public string DeviceName { get; set; } = string.Empty;

    /// <summary>
    /// Device connection status
    /// </summary>
    public bool IsConnected { get; set; }

    /// <summary>
    /// Last communication timestamp
    /// </summary>
    public DateTime LastCommunicationTime { get; set; }

    /// <summary>
    /// Device type
    /// </summary>
    public abstract string DeviceType { get; }
}
