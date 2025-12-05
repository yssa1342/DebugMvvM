# Quick Start Guide / 快速入门指南

## Project Summary / 项目概述

This is a WPF+MVVM upper computer application for monitoring two device types:
- **Vdc_32**: Single-channel power monitoring device
- **GJ750_4_60A**: Four-channel power monitoring device

这是一个WPF+MVVM架构的上位机应用程序，用于监控两种设备：
- **Vdc_32**：单通道电源监控设备
- **GJ750_4_60A**：四通道电源监控设备

## Prerequisites / 前置要求

- .NET 10.0 SDK (installed / 已安装)
- Windows operating system / Windows 操作系统
- Visual Studio 2022 or VS Code / Visual Studio 2022 或 VS Code

## Quick Start / 快速开始

### 1. Build the Project / 构建项目

```bash
cd /home/runner/work/DebugMvvM/DebugMvvM
dotnet build
```

### 2. Run the Application / 运行应用

```bash
dotnet run --project src/DebugMvvM.App/DebugMvvM.App.csproj
```

### 3. Using the Application / 使用应用

1. The main window shows a navigation panel on the left
   主窗口左侧显示导航面板

2. Click "Vdc_32 Device" or "GJ750_4_60A Device" to switch views
   点击 "Vdc_32 Device" 或 "GJ750_4_60A Device" 切换视图

3. Click "Connect" to simulate device connection
   点击 "Connect" 模拟设备连接

4. Click "Read Data" to update device values
   点击 "Read Data" 更新设备数值

5. Click "Disconnect" to disconnect from device
   点击 "Disconnect" 断开设备连接

## Project Structure / 项目结构

```
DebugMvvM/
├── DebugMvvM.sln              # Solution file / 解决方案文件
├── README.md                   # Full documentation / 完整文档
├── ARCHITECTURE.md             # Architecture details / 架构详情
└── src/
    ├── DebugMvvM.App/         # WPF UI Layer / WPF 界面层
    ├── DebugMvvM.ViewModels/  # ViewModels / 视图模型层
    ├── DebugMvvM.Models/      # Data Models / 数据模型层
    ├── DebugMvvM.Services/    # Business Logic / 业务逻辑层
    └── DebugMvvM.Infrastructure/ # Common Utilities / 通用工具层
```

## Key Features / 主要功能

✅ Clean MVVM architecture / 清晰的MVVM架构
✅ Support for two device types / 支持两种设备类型
✅ Real-time data monitoring / 实时数据监控
✅ Connection management / 连接管理
✅ Modern, colorful UI / 现代化彩色界面
✅ Extensible design / 可扩展设计

## Build Commands / 构建命令

```bash
# Debug build / 调试构建
dotnet build

# Release build / 发布构建
dotnet build --configuration Release

# Clean build / 清理构建
dotnet clean
dotnet build

# Restore packages / 还原包
dotnet restore
```

## Project Information / 项目信息

| Item / 项目 | Value / 值 |
|------------|-----------|
| Framework / 框架 | .NET 10.0 (Windows) |
| Language / 语言 | C# |
| Architecture / 架构 | MVVM |
| UI Framework / UI框架 | WPF |
| MVVM Toolkit / MVVM工具包 | CommunityToolkit.Mvvm 8.4.0 |
| Projects / 项目数 | 5 |

## Devices / 设备

### Vdc_32
- Single channel / 单通道
- Monitors: Voltage, Current, Power, Temperature
- 监控：电压、电流、功率、温度

### GJ750_4_60A
- Four channels / 四通道
- Each channel monitors: Voltage, Current
- 每通道监控：电压、电流
- Total power calculation / 总功率计算

## Next Steps / 下一步

1. Review README.md for complete documentation
   查看 README.md 获取完整文档

2. Review ARCHITECTURE.md for technical details
   查看 ARCHITECTURE.md 获取技术详情

3. Implement actual device communication protocols
   实现实际设备通信协议

4. Add tests / 添加测试
   ```bash
   # Add test project
   dotnet new xunit -n DebugMvvM.Tests -o tests/DebugMvvM.Tests
   dotnet sln add tests/DebugMvvM.Tests/DebugMvvM.Tests.csproj
   ```

## Important Notes / 重要说明

⚠️ Current implementation uses simulated data
⚠️ 当前实现使用模拟数据

⚠️ Device services need actual protocol implementation
⚠️ 设备服务需要实现实际协议

⚠️ Connection parameters need to be configured
⚠️ 需要配置连接参数

## Getting Help / 获取帮助

- Check README.md for detailed information / 查看 README.md 获取详细信息
- Check ARCHITECTURE.md for architecture details / 查看 ARCHITECTURE.md 获取架构详情
- Review code comments / 查看代码注释
- Check TODO comments in service implementations / 查看服务实现中的 TODO 注释

## License / 许可证

To be determined / 待定

## Version / 版本

1.0.0 - Initial Release / 初始版本
