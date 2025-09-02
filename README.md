# Avalonia IOC AOT Sample (.NET 9)

[![.NET Version](https://img.shields.io/badge/.NET-9.0-blue.svg)](https://dotnet.microsoft.com/download/dotnet/9.0)
[![Avalonia UI](https://img.shields.io/badge/Avalonia%20UI-11.x-purple.svg)](https://avaloniaui.net/)
[![NativeAOT](https://img.shields.io/badge/NativeAOT-Ready-green.svg)](https://docs.microsoft.com/en-us/dotnet/core/deploying/native-aot/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

## 📖 Overview

This repository demonstrates how to build **NativeAOT-compatible** desktop applications using **Avalonia UI** with two different **Dependency Injection (DI)** approaches. It serves as a comprehensive example for developers seeking to optimize performance and reduce runtime overhead by leveraging AOT compilation in .NET 9.

### 🎯 Project Goals

- **Performance Optimization**: Demonstrate NativeAOT compilation for faster startup and reduced memory footprint
- **DI Container Comparison**: Showcase two different AOT-compatible dependency injection approaches
- **Best Practices**: Provide a template for building reflection-free Avalonia applications
- **Cross-Platform**: Support Windows, Linux, and macOS with native binaries

## 🏗️ Architecture

### Project Structure
```
├── AvaloniaDryIocAot/          # DryIoc implementation
│   ├── Services/
│   ├── ViewModels/
│   ├── Views/
│   ├── App.axaml.cs
│   └── Program.cs
├── AvaloniaPureDIAot/          # Pure.DI implementation
│   ├── Services/
│   ├── ViewModels/
│   ├── Views/
│   ├── App.axaml.cs
│   ├── Composition.cs          # Pure.DI configuration
│   └── Program.cs
└── README.md
```

### 🔧 Technology Stack

- **UI Framework**: [Avalonia UI](https://avaloniaui.net/) - Cross-platform .NET UI framework
- **Language**: C# 12
- **Runtime**: .NET 9
- **Compilation**: NativeAOT (Ahead-of-Time compilation)
- **Design Pattern**: MVVM (Model-View-ViewModel)

### 📦 Dependency Injection Containers

#### 1. AvaloniaDryIocAot - DryIoc Container
- **Container**: [DryIoc](https://github.com/dadhi/DryIoc)
- **Approach**: Explicit service registrations
- **AOT Compatibility**: Manual registration without reflection
- **Benefits**: Full control over service lifetime and registration

#### 2. AvaloniaPureDIAot - Pure.DI Container
- **Container**: [Pure.DI](https://github.com/DevTeam/Pure.DI)
- **Approach**: Source generator-based compile-time DI
- **AOT Compatibility**: Zero runtime overhead, compile-time code generation
- **Benefits**: Fastest performance, no runtime container overhead

## 🚀 Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- IDE: Visual Studio 2022, JetBrains Rider, or VS Code
- Git (for cloning and version control)

### 🛠️ Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/YourUsername/Avalonia_IOC_AOT_Sample.git
   cd Avalonia_IOC_AOT_Sample
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the solution**
   ```bash
   dotnet build
   ```

### 🏃‍♂️ Running the Applications

#### Development Mode
```bash
# Run DryIoc version
dotnet run --project AvaloniaDryIocAot

# Run Pure.DI version
dotnet run --project AvaloniaPureDIAot
```

#### Debug Build
```bash
dotnet build -c Debug
dotnet run --project AvaloniaDryIocAot -c Debug
```

### 📦 Publishing NativeAOT Binaries

#### Windows x64
```bash
dotnet publish AvaloniaDryIocAot -c Release -r win-x64 --self-contained true -p:PublishAot=true
dotnet publish AvaloniaPureDIAot -c Release -r win-x64 --self-contained true -p:PublishAot=true
```

#### Linux x64
```bash
dotnet publish AvaloniaDryIocAot -c Release -r linux-x64 --self-contained true -p:PublishAot=true
dotnet publish AvaloniaPureDIAot -c Release -r linux-x64 --self-contained true -p:PublishAot=true
```

#### macOS ARM64 (Apple Silicon)
```bash
dotnet publish AvaloniaDryIocAot -c Release -r osx-arm64 --self-contained true -p:PublishAot=true
dotnet publish AvaloniaPureDIAot -c Release -r osx-arm64 --self-contained true -p:PublishAot=true
```

#### All Supported Runtime Identifiers (RIDs)
- `win-x64`, `win-x86`, `win-arm64`
- `linux-x64`, `linux-arm64`
- `osx-x64`, `osx-arm64`

## 🔍 Key Features & Implementation Details

### ✅ NativeAOT Compatibility Features

1. **Compiled Bindings**: All XAML bindings use `{CompiledBinding}` to eliminate reflection
   ```xml
   <TextBlock Text="{CompiledBinding CurrentTime}" />
   ```

2. **Explicit Service Registration**: No assembly scanning or runtime discovery
   ```csharp
   // DryIoc example
   container.Register<ITimeService, TimeService>(Reuse.Singleton);
   ```

3. **Source Generator DI**: Pure.DI generates container code at compile time
   ```csharp
   // Pure.DI example
   DI.Setup(nameof(Composition))
       .Bind<ITimeService>().To<TimeService>()
       .Root<MainWindowViewModel>("Root");
   ```

### 🎨 MVVM Implementation

- **Services**: Business logic and data access (`ITimeService`, `TimeService`)
- **ViewModels**: UI logic and data binding (`MainWindowViewModel`)
- **Views**: XAML UI definitions (`MainWindow.axaml`)
- **Dependency Injection**: Service resolution and lifecycle management

### ⚡ Performance Benefits

- **Faster Startup**: NativeAOT eliminates JIT compilation overhead
- **Smaller Memory Footprint**: No need for .NET runtime in deployment
- **Better Cold Start**: Native binaries start immediately
- **Compile-Time Optimizations**: Dead code elimination and inlining

## 📊 Performance Comparison

| Metric | Regular .NET | NativeAOT |
|--------|-------------|------------|
| Startup Time | ~1-2s | ~100-300ms |
| Memory Usage | ~50-100MB | ~10-30MB |
| Binary Size | ~200MB+ | ~10-50MB |
| Deployment | Requires .NET Runtime | Self-contained |

## 🛡️ Technical Constraints & Best Practices

### ✅ AOT-Compatible Patterns
- Use interfaces for dependency injection
- Prefer compiled bindings over reflection-based bindings
- Avoid `Activator.CreateInstance()` and runtime type creation
- Use source generators instead of runtime code generation

### ❌ AOT-Incompatible Patterns
- Runtime reflection (`Type.GetType()`, `Assembly.LoadFrom()`)
- Dynamic proxy generation
- Runtime code compilation (`System.CodeDom.Compiler`)
- Assembly scanning with `Assembly.GetTypes()`

## 🧪 Testing

```bash
# Run tests (if available)
dotnet test

# Test NativeAOT compilation
dotnet publish -c Release -r win-x64 -p:PublishAot=true --verbosity normal
```

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Commit your changes (`git commit -m 'Add some amazing feature'`)
4. Push to the branch (`git push origin feature/amazing-feature`)
5. Open a Pull Request

### Development Guidelines
- Follow C# coding conventions
- Ensure NativeAOT compatibility for all changes
- Add tests for new features
- Update documentation as needed

## 📝 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- [Avalonia UI Team](https://avaloniaui.net/) for the excellent cross-platform UI framework
- [DryIoc](https://github.com/dadhi/DryIoc) for the lightweight IoC container
- [Pure.DI](https://github.com/DevTeam/Pure.DI) for compile-time dependency injection
- [.NET Team](https://dotnet.microsoft.com/) for NativeAOT support

## 📚 Additional Resources

- [Avalonia UI Documentation](https://docs.avaloniaui.net/)
- [.NET NativeAOT Documentation](https://docs.microsoft.com/en-us/dotnet/core/deploying/native-aot/)
- [DryIoc Documentation](https://github.com/dadhi/DryIoc/blob/master/docs/DryIoc.Docs/)
- [Pure.DI Documentation](https://github.com/DevTeam/Pure.DI#readme)

## 🐛 Troubleshooting

### Common Issues

1. **Build Errors with NativeAOT**
   - Ensure all dependencies are AOT-compatible
   - Check for reflection usage in third-party libraries

2. **Runtime Exceptions in AOT Build**
   - Verify all services are properly registered
   - Check for missing constructors or circular dependencies

3. **Binding Issues**
   - Ensure ViewModels implement `INotifyPropertyChanged`
   - Use `{CompiledBinding}` instead of `{Binding}`

### Getting Help
- Open an [Issue](https://github.com/YourUsername/Avalonia_IOC_AOT_Sample/issues)
- Check [Avalonia Community](https://github.com/AvaloniaUI/Avalonia/discussions)
- Visit [.NET Community](https://dotnet.microsoft.com/platform/community)

---

**⭐ If this project helps you, please consider giving it a star!**
