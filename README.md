
# Mountain Share

A cross-platform mobile application built with .NET MAUI that provides an interface for sharing outdoor equipment and services (ski, bike, hiking, climbing). Inspired by the UI concept of OutdoorShare.

## 📱 Features

- 🔍 Search bar to find equipment, guides, and services
- 🏂 Category filters (Ski, Bike, Hiking, Climbing)
- 🎿 Display available equipment
- 🧑‍🏔 Display local guides
- 🚌 Display shuttle transport information
- 📥 Bottom Tab Navigation: Home, Search, Publish, Messages, Profile

## 📁 Project Structure

```
OutdoorShareMauiApp/
│
├── AppShell/
│   ├── AppShell.xaml
│   └── AppShell.xaml.cs
│
├── Pages/
│   ├── HomePage.xaml / .cs
│   ├── SearchPage.xaml / .cs
│   ├── PublishPage.xaml / .cs
│   ├── MessagesPage.xaml / .cs
│   └── ProfilePage.xaml / .cs
│
├── Resources/
│   └── Images/
│       └── (Icons and equipment images)
│
├── App.xaml
└── App.xaml.cs
```

## ⚙ Requirements

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Visual Studio 2022 or newer with MAUI workload installed

## 🚀 Getting Started

1. Clone the repository:

```bash
git clone https://github.com/rlocoselli/OutdoorShareMauiApp.git
cd OutdoorShareMauiApp
```

2. Restore dependencies and build:

```bash
dotnet restore
dotnet build
```

3. Run the application:

```bash
dotnet maui run
```

> You can also run and debug the app using Visual Studio.

## 📷 Screenshots

![screenshot](docs/screenshot.png)

## 📂 License

This project is licensed under the MIT License. Feel free to use and modify.

---

Made with ❤️ by rlocoselli
