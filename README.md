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
    ├── CustomerInfo.cs         # Customer data model
    ├── Order.cs                # Order data model
    ├── OrderItem.cs            # Order line item data model
    ├── OrderStatus.cs          # Order status enum
    ├── Product.cs              # Product data model
    ├── IOrderRepository.cs     # Order repository interface
    └── OrderRepository.cs      # In-memory order repository implementation
```

The solution is organized around a single console project. The entry point lives
in `Program.cs`, while the `Models` folder contains the data types and the order
repository used by the app.

## Order Repository

The `IOrderRepository` interface defines the contract for order management operations:

- **Insert** – add a new order to the repository
- **Update** – replace an existing order with an updated version
- **Delete** – remove an order by its ID
- **Search** – find orders by customer name or by order ID
- **GetById** – retrieve a single order by its ID

The `OrderRepository` class provides an in-memory implementation of this interface.
The interface makes it straightforward to swap in a database-backed implementation
in the future without changing any calling code.

### Example usage

```csharp
IOrderRepository repository = new OrderRepository();

// Insert
var customer = new CustomerInfo("Smith", "John", "123 Main St");
var order = new Order(1001, customer);
order.AddItem(new OrderItem(new Product("Laptop", "LAP-001", 1299.99m), 1));
repository.Insert(order);

// Retrieve
var found = repository.GetById(1001);

// Update
order.UpdateStatus(OrderStatus.Completed);
repository.Update(order);

// Search by customer name
var results = repository.Search("Smith");

// Search by order ID
var byId = repository.Search(1001);

// Delete
repository.Delete(1001);
```

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