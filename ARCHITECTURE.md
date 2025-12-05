# DebugMvvM - 项目架构文档 (Project Architecture Document)

## 项目概述 (Project Overview)

本项目是一个基于WPF+MVVM架构的上位机应用程序，用于监控和控制两种设备：
- Vdc_32：单通道电源监控设备
- GJ750_4_60A：四通道电源监控设备

This project is an upper computer application based on WPF+MVVM architecture for monitoring and controlling two device types:
- Vdc_32: Single-channel power monitoring device
- GJ750_4_60A: Four-channel power monitoring device

## 技术选型 (Technology Stack)

| 组件 | 技术/版本 |
|------|-----------|
| 目标框架 (Framework) | .NET 10.0 (Windows) |
| UI框架 (UI Framework) | WPF (Windows Presentation Foundation) |
| 架构模式 (Architecture) | MVVM (Model-View-ViewModel) |
| 编程语言 (Language) | C# 10+ |
| MVVM工具包 (MVVM Toolkit) | CommunityToolkit.Mvvm 8.4.0 |

## 项目结构详解 (Detailed Project Structure)

### 1. DebugMvvM.App (表示层 / Presentation Layer)

**职责 (Responsibilities):**
- 用户界面展示 (User interface presentation)
- 用户交互处理 (User interaction handling)
- 数据绑定 (Data binding)

**主要文件 (Key Files):**
- `MainWindow.xaml`: 主窗口，包含导航菜单和内容区域
- `Views/Vdc32View.xaml`: Vdc_32设备监控界面
- `Views/GJ750_4_60AView.xaml`: GJ750_4_60A设备监控界面
- `Converters/InverseBoolConverter.cs`: 布尔值反转转换器

**UI设计特点 (UI Design Features):**
- 侧边导航栏切换不同设备视图
- 实时数据展示卡片式设计
- 连接/断开/读取数据操作按钮
- 彩色编码的度量指标显示

### 2. DebugMvvM.ViewModels (视图模型层 / ViewModel Layer)

**职责 (Responsibilities):**
- 表示逻辑 (Presentation logic)
- 数据绑定源 (Data binding source)
- 命令处理 (Command handling)
- 视图状态管理 (View state management)

**核心类 (Core Classes):**

#### ViewModelBase
```csharp
public abstract class ViewModelBase : ObservableObject
{
    public string Title { get; set; }
}
```
所有ViewModel的基类，继承自ObservableObject以支持属性变更通知。

#### MainViewModel
- 管理设备视图切换 (Manages device view switching)
- 命令：SwitchToVdc32Command, SwitchToGJ750Command
- 属性：CurrentViewModel, Vdc32ViewModel, Gj750ViewModel

#### Vdc32ViewModel / GJ750_4_60AViewModel
- 设备连接管理 (Device connection management)
- 数据读取和更新 (Data reading and updating)
- 命令：ConnectCommand, DisconnectCommand, ReadDataCommand
- 属性：Device, IsConnected, ConnectionStatus

### 3. DebugMvvM.Models (数据模型层 / Model Layer)

**职责 (Responsibilities):**
- 定义数据结构 (Define data structures)
- 业务实体表示 (Business entity representation)

**模型类 (Model Classes):**

#### DeviceBase (抽象基类)
```csharp
public abstract class DeviceBase
{
    public string DeviceId { get; set; }
    public string DeviceName { get; set; }
    public bool IsConnected { get; set; }
    public DateTime LastCommunicationTime { get; set; }
    public abstract string DeviceType { get; }
}
```

#### Vdc32Device
- Voltage (电压)
- Current (电流)
- Power (功率)
- Temperature (温度)
- Status (状态)
- HasAlarm (告警状态)
- AlarmMessage (告警消息)

#### GJ750_4_60ADevice
- Channel1-4 Voltage/Current (通道1-4电压/电流)
- TotalPower (总功率)
- Temperature (温度)
- Status (状态)
- HasAlarm (告警状态)
- AlarmMessage (告警消息)
- ActiveChannels (活动通道数)

### 4. DebugMvvM.Services (服务层 / Service Layer)

**职责 (Responsibilities):**
- 设备通信逻辑 (Device communication logic)
- 业务规则实现 (Business rule implementation)
- 数据处理 (Data processing)

**接口定义 (Interface Definition):**
```csharp
public interface IDeviceService
{
    Task<bool> ConnectAsync(DeviceBase device);
    Task DisconnectAsync(DeviceBase device);
    Task<DeviceBase?> ReadDataAsync(DeviceBase device);
    Task<bool> WriteDataAsync(DeviceBase device, object data);
    bool IsConnected(DeviceBase device);
}
```

**实现类 (Implementation Classes):**
- `Vdc32Service`: Vdc_32设备服务实现
- `GJ750_4_60AService`: GJ750_4_60A设备服务实现

**注意 (Note):**
当前实现使用模拟数据。实际部署时需要：
- 实现具体的通信协议（串口/TCP/UDP等）
- 添加错误处理和重连机制
- 实现数据校验和解析逻辑

### 5. DebugMvvM.Infrastructure (基础设施层 / Infrastructure Layer)

**职责 (Responsibilities):**
- 提供可重用组件 (Provide reusable components)
- 实现通用功能 (Implement common functionality)

**核心类 (Core Classes):**

#### ObservableObject
```csharp
public abstract class ObservableObject : INotifyPropertyChanged
{
    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null);
    protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null);
}
```

#### RelayCommand
```csharp
public class RelayCommand : ICommand
{
    // ICommand implementation for MVVM pattern
}
```

## MVVM数据流 (MVVM Data Flow)

```
┌─────────────┐         ┌──────────────┐         ┌─────────────┐
│    View     │ ◄────── │  ViewModel   │ ◄────── │   Service   │
│   (XAML)    │ ──────► │  (Commands)  │ ──────► │ (Business)  │
└─────────────┘         └──────────────┘         └─────────────┘
      │                        │                         │
      │                        │                         │
      └────── Data Binding ────┘                         │
                                                          │
                                              ┌───────────▼────────┐
                                              │      Model         │
                                              │   (Data Entity)    │
                                              └────────────────────┘
```

## 项目依赖关系 (Project Dependencies)

```
DebugMvvM.App
    │
    ├─► DebugMvvM.ViewModels
    │       │
    │       ├─► DebugMvvM.Models
    │       ├─► DebugMvvM.Services
    │       └─► DebugMvvM.Infrastructure
    │
    ├─► DebugMvvM.Services
    │       │
    │       ├─► DebugMvvM.Models
    │       └─► DebugMvvM.Infrastructure
    │
    └─► DebugMvvM.Infrastructure
```

## 构建和运行 (Build and Run)

### 前置条件 (Prerequisites)
1. 安装 .NET 10.0 SDK
2. Windows 操作系统
3. Visual Studio 2022 或 VS Code

### 构建命令 (Build Commands)
```bash
# 还原依赖
dotnet restore

# 调试构建
dotnet build

# 发布构建
dotnet build --configuration Release

# 运行应用
dotnet run --project src/DebugMvvM.App/DebugMvvM.App.csproj
```

## 扩展指南 (Extension Guide)

### 添加新设备 (Adding New Device)

1. **创建模型 (Create Model)**
   ```csharp
   public class NewDevice : DeviceBase
   {
       public override string DeviceType => "NewDevice";
       // Add device-specific properties
   }
   ```

2. **创建服务 (Create Service)**
   ```csharp
   public class NewDeviceService : IDeviceService
   {
       // Implement IDeviceService methods
   }
   ```

3. **创建ViewModel (Create ViewModel)**
   ```csharp
   public partial class NewDeviceViewModel : ViewModelBase
   {
       // Add device-specific logic
   }
   ```

4. **创建视图 (Create View)**
   ```xaml
   <UserControl x:Class="DebugMvvM.App.Views.NewDeviceView">
       <!-- Add UI elements -->
   </UserControl>
   ```

5. **更新MainViewModel**
   - 添加新设备ViewModel属性
   - 添加切换命令

6. **更新MainWindow**
   - 添加DataTemplate
   - 添加导航按钮

## 设计模式 (Design Patterns)

### 1. MVVM Pattern
- 分离关注点 (Separation of concerns)
- 可测试性 (Testability)
- 数据绑定 (Data binding)

### 2. Service Pattern
- 业务逻辑封装 (Business logic encapsulation)
- 依赖注入就绪 (Dependency injection ready)

### 3. Repository Pattern (未来扩展)
- 数据持久化 (Data persistence)
- 数据访问抽象 (Data access abstraction)

## 最佳实践 (Best Practices)

1. **命名约定 (Naming Convention)**
   - ViewModel类以"ViewModel"结尾
   - View类以"View"结尾
   - Service类以"Service"结尾
   - 使用有意义的命名

2. **依赖注入 (Dependency Injection)**
   - 当前使用构造函数创建依赖
   - 建议使用DI容器（如Microsoft.Extensions.DependencyInjection）

3. **异步编程 (Async Programming)**
   - 所有I/O操作使用async/await
   - 避免阻塞UI线程

4. **错误处理 (Error Handling)**
   - 添加try-catch块
   - 记录错误日志
   - 向用户展示友好错误信息

## 性能考虑 (Performance Considerations)

1. **数据更新频率 (Data Update Frequency)**
   - 当前每秒更新一次
   - 可根据需求调整

2. **内存管理 (Memory Management)**
   - 及时释放资源
   - 取消订阅事件

3. **UI响应性 (UI Responsiveness)**
   - 使用异步操作
   - 避免在UI线程执行耗时操作

## 安全考虑 (Security Considerations)

1. **通信安全 (Communication Security)**
   - 实现加密通信
   - 验证设备身份

2. **访问控制 (Access Control)**
   - 添加用户认证
   - 实现权限管理

3. **数据验证 (Data Validation)**
   - 验证输入数据
   - 防止注入攻击

## 未来改进 (Future Improvements)

- [ ] 实现依赖注入容器
- [ ] 添加单元测试
- [ ] 实现日志系统
- [ ] 添加配置管理
- [ ] 实现数据持久化
- [ ] 添加国际化支持
- [ ] 实现插件架构
- [ ] 添加数据可视化（图表）
- [ ] 实现远程监控功能

## 许可证 (License)

待定 (To be determined)

## 贡献者 (Contributors)

待添加 (To be added)
