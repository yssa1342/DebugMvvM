namespace DebugMvvM.Models;

/// <summary>
/// Vdc_32 device model
/// </summary>
public class Vdc32Device : DeviceBase
{
    public override string DeviceType => "Vdc_32";

    /// <summary>
    /// Voltage value (V)
    /// </summary>
    public double Voltage { get; set; }

    /// <summary>
    /// Current value (A)
    /// </summary>
    public double Current { get; set; }

    /// <summary>
    /// Power value (W)
    /// </summary>
    public double Power { get; set; }

    /// <summary>
    /// Temperature (°C)
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
}
