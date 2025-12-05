# DebugMvvM

A WPF application using MVVM architecture for upper computer device monitoring and control, supporting two device types: Vdc_32 and GJ750_4_60A.

## Technology Stack

- **Framework**: .NET 10.0 (Windows)
- **UI Framework**: WPF (Windows Presentation Foundation)
- **Architecture**: MVVM (Model-View-ViewModel)
- **Language**: C#
- **MVVM Toolkit**: CommunityToolkit.Mvvm 8.4.0

## Project Structure

```
DebugMvvM/
├── DebugMvvM.sln                    # Solution file
├── README.md                         # Project documentation
└── src/
    ├── DebugMvvM.App/               # WPF Application (Presentation Layer)
    │   ├── Views/                   # XAML Views
    │   │   ├── Vdc32View.xaml      # Vdc_32 device view
    │   │   └── GJ750_4_60AView.xaml # GJ750_4_60A device view
    │   ├── Converters/              # Value Converters
    │   │   └── InverseBoolConverter.cs
    │   ├── MainWindow.xaml          # Main application window
    │   ├── App.xaml                 # Application resources
    │   └── DebugMvvM.App.csproj
    │
    ├── DebugMvvM.ViewModels/        # ViewModels (Presentation Logic)
    │   ├── ViewModelBase.cs         # Base class for all ViewModels
    │   ├── MainViewModel.cs         # Main window ViewModel
    │   ├── Vdc32ViewModel.cs        # Vdc_32 device ViewModel
    │   ├── GJ750_4_60AViewModel.cs  # GJ750_4_60A device ViewModel
    │   └── DebugMvvM.ViewModels.csproj
    │
    ├── DebugMvvM.Models/            # Models (Data Layer)
    │   ├── DeviceBase.cs            # Base device model
    │   ├── Vdc32Device.cs           # Vdc_32 device model
    │   ├── GJ750_4_60ADevice.cs     # GJ750_4_60A device model
    │   └── DebugMvvM.Models.csproj
    │
    ├── DebugMvvM.Services/          # Services (Business Logic)
    │   ├── IDeviceService.cs        # Device service interface
    │   ├── Vdc32Service.cs          # Vdc_32 device service
    │   ├── GJ750_4_60AService.cs    # GJ750_4_60A device service
    │   └── DebugMvvM.Services.csproj
    │
    └── DebugMvvM.Infrastructure/    # Infrastructure (Common Utilities)
        ├── ObservableObject.cs      # Base class for observable objects
        ├── RelayCommand.cs          # Command implementation
        └── DebugMvvM.Infrastructure.csproj
```

## Layer Responsibilities

### 1. DebugMvvM.App (Presentation Layer)
- Contains all XAML views and UI-related code
- Implements the user interface for device monitoring
- Handles user interactions through data binding
- Uses Material Design-inspired color scheme

### 2. DebugMvvM.ViewModels (Presentation Logic)
- Implements ViewModels using CommunityToolkit.Mvvm
- Provides data binding for Views
- Handles user commands (Connect, Disconnect, Read Data)
- Manages UI state and device selection

### 3. DebugMvvM.Models (Data Layer)
- Defines device data structures
- **DeviceBase**: Abstract base class for all devices
  - Common properties: DeviceId, DeviceName, IsConnected, LastCommunicationTime
- **Vdc32Device**: Model for Vdc_32 device
  - Properties: Voltage, Current, Power, Temperature, Status
- **GJ750_4_60ADevice**: Model for GJ750_4_60A device
  - Properties: 4 channels (Voltage/Current per channel), TotalPower, Temperature, Status

### 4. DebugMvvM.Services (Business Logic)
- Implements device communication logic
- **IDeviceService**: Common interface for all device services
- **Vdc32Service**: Handles Vdc_32 device operations
- **GJ750_4_60AService**: Handles GJ750_4_60A device operations
- Methods: ConnectAsync, DisconnectAsync, ReadDataAsync, WriteDataAsync

### 5. DebugMvvM.Infrastructure (Common Utilities)
- Provides reusable components
- **ObservableObject**: Base implementation of INotifyPropertyChanged
- **RelayCommand**: ICommand implementation for MVVM pattern

## Device Specifications

### Vdc_32 Device
- Single channel power supply/monitoring device
- Measurements:
  - Voltage (V)
  - Current (A)
  - Power (W)
  - Temperature (°C)
- Status monitoring and alarm handling

### GJ750_4_60A Device
- 4-channel power supply/monitoring device
- Each channel monitors:
  - Voltage (V)
  - Current (A)
- Total power calculation across all channels
- Temperature monitoring
- Status and alarm handling

## Building the Project

### Prerequisites
- .NET 10.0 SDK or later
- Windows operating system (for WPF)
- Visual Studio 2022 or VS Code with C# extension

### Build Commands

```bash
# Restore dependencies
dotnet restore

# Build the solution
dotnet build

# Run the application
dotnet run --project src/DebugMvvM.App/DebugMvvM.App.csproj
```

## Features

- ✅ MVVM architecture with clean separation of concerns
- ✅ Support for multiple device types
- ✅ Real-time device monitoring
- ✅ Device connection management
- ✅ Data refresh functionality
- ✅ Modern UI with color-coded metrics
- ✅ Navigation between device views
- ✅ Extensible architecture for adding new devices

## Adding New Devices

To add support for a new device type:

1. **Create Model**: Add a new class in `DebugMvvM.Models` inheriting from `DeviceBase`
2. **Create Service**: Implement `IDeviceService` in `DebugMvvM.Services`
3. **Create ViewModel**: Add a ViewModel in `DebugMvvM.ViewModels` inheriting from `ViewModelBase`
4. **Create View**: Add a UserControl in `DebugMvvM.App/Views`
5. **Update MainViewModel**: Add navigation command and reference
6. **Update MainWindow**: Add DataTemplate and navigation button

## Communication Protocol

The current implementation uses placeholder/simulated data. To integrate with actual devices:

1. Implement device-specific communication protocol in the Service layer
2. Update `ConnectAsync`, `DisconnectAsync`, `ReadDataAsync`, and `WriteDataAsync` methods
3. Add necessary communication libraries (Serial, TCP/IP, etc.)
4. Configure connection parameters (COM port, IP address, etc.)

## Future Enhancements

- [ ] Implement actual device communication protocols
- [ ] Add data logging functionality
- [ ] Implement alarm management system
- [ ] Add configuration management
- [ ] Create device calibration features
- [ ] Add data visualization (charts/graphs)
- [ ] Implement user authentication
- [ ] Add multi-language support
- [ ] Create help documentation

## License

[Add your license information here]

## Contributors

[Add contributor information here]
