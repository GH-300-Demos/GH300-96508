# MyAmazingApp

A simple .NET 10 console application that prints "Hello, World!" to the terminal. This project serves as a starter template for building .NET console applications.

## Goal

The goal of this project is to provide a minimal starting point for a .NET 10
console application. It is intended to be easy to build on, whether you want to
experiment with console features, add domain models, or use it as the base for
larger command-line workflows.

## Structure

```
MyAmazingApp.slnx              # Solution file
MyAmazingConsole/
├── MyAmazingConsole.csproj     # Project file targeting .NET 10
├── Program.cs                  # Application entry point
└── Models/                     # Domain model classes used by the app
```

The solution is organized around a single console project. The entry point lives
in `Program.cs`, while the `Models` folder contains the basic data types that can
be expanded as the application grows.

## Usage

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later

### Run the application

```bash
dotnet run --project MyAmazingConsole
```

### Build, then run

```bash
dotnet build
dotnet run --project MyAmazingConsole
```

You can use this repository as a starter template for experimenting with .NET
console development, adding new commands, or expanding the included models into
basic application workflows.