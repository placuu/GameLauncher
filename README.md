# 🎮 Game Launcher & Library Manager

A desktop application built with WPF and .NET for organizing and launching your PC games — inspired by platforms like Steam and GOG Galaxy.

---

## 📌 About This Project

This is an educational/portfolio project created to learn:

- MVVM architecture in WPF
- Local database management with Entity Framework Core
- Process monitoring and event handling in C#
- Building modern dark-themed desktop UIs

---

## 🚀 Features

- 📁 **Game Library Management** — Add, edit, and remove games from your local database
- 💾 **Persistent Storage** — SQLite database keeps your library saved between sessions
- ⏱️ **Time Tracking** — Real-time monitoring of "Time Played" for each launched title
- 🎨 **Custom UI** — Dark-themed modern interface inspired by Steam and GOG Galaxy

---

## 💻 Requirements

- Windows 10 / 11
- .NET 8 SDK or higher
- Visual Studio 2022 (recommended)

---

## 📖 How to Use

1. Clone the repository
2. Open solution in Visual Studio
3. Build and run the project
4. Add your games using the **Add Game** button
5. Launch games directly from the library

---

## 🛠️ Technologies Used

- C# / .NET
- WPF (XAML)
- Entity Framework Core
- SQLite

---

## 🏗️ Architecture

This project follows the **MVVM** pattern:

---
**GameLauncher/**
- `Assets/` — icons and images
- `Data/` — database context
- `Models/` — data models
- `ViewModels/` — business logic and data binding
- `Views/` — XAML UI definitions
- `Themes/` — styles and button themes
- `App.xaml` — application entry point

---

## 📚 What I Learned

- Implementing CRUD operations in a desktop environment
- Managing process start/exit events for time tracking
- Data binding with the MVVM pattern
- Working with Entity Framework Core and SQLite
