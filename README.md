# MyAmazingApp

A simple .NET 10 console application that prints "Hello, World!" to the terminal. This project serves as a starter template for building .NET console applications.

## Project Structure

```
MyAmazingApp.slnx              # Solution file
MyAmazingConsole/
├── MyAmazingConsole.csproj     # Project file targeting .NET 10
└── Program.cs                  # Application entry point
```

## How to Run

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download) or later

### Build and Run

```bash
dotnet run --project MyAmazingConsole
```

Or build first, then run the compiled output:

```bash
dotnet build
dotnet run --project MyAmazingConsole
```