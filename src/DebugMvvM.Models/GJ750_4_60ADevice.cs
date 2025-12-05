namespace DebugMvvM.Models;

/// <summary>
/// GJ750_4_60A device model
/// </summary>
public class GJ750_4_60ADevice : DeviceBase
{
    public override string DeviceType => "GJ750_4_60A";

    /// <summary>
    /// Channel 1 Voltage (V)
    /// </summary>
    public double Channel1Voltage { get; set; }

    /// <summary>
    /// Channel 1 Current (A)
    /// </summary>
    public double Channel1Current { get; set; }

    /// <summary>
    /// Channel 2 Voltage (V)
    /// </summary>
    public double Channel2Voltage { get; set; }

    /// <summary>
    /// Channel 2 Current (A)
    /// </summary>
    public double Channel2Current { get; set; }

    /// <summary>
    /// Channel 3 Voltage (V)
    /// </summary>
    public double Channel3Voltage { get; set; }

    /// <summary>
    /// Channel 3 Current (A)
    /// </summary>
    public double Channel3Current { get; set; }

    /// <summary>
    /// Channel 4 Voltage (V)
    /// </summary>
    public double Channel4Voltage { get; set; }

    /// <summary>
    /// Channel 4 Current (A)
    /// </summary>
    public double Channel4Current { get; set; }

    /// <summary>
    /// Total power output (W)
    /// </summary>
    public double TotalPower { get; set; }

    /// <summary>
    /// Device temperature (°C)
    /// </summary>
    public double Temperature { get; set; }

    /// <summary>
    /// Operating status
    /// </summary>
    public string Status { get; set; } = "Ready";

    /// <summary>
    /// Alarm status
    /// </summary>
    public bool HasAlarm { get; set; }

    /// <summary>
    /// Alarm message
    /// </summary>
    public string AlarmMessage { get; set; } = string.Empty;

    /// <summary>
    /// Active channel count
    /// </summary>
    public int ActiveChannels { get; set; } = 4;
}
