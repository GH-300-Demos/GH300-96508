using MyAmazingConsole.Models;

Console.WriteLine("=== E-Commerce Order Management Demo ===\n");

// --- Setup: create customers and products ---
var customer1 = new CustomerInfo("Smith", "John", "123 Main Street, New York, NY 10001");
var customer2 = new CustomerInfo("Johnson", "Emma", "456 Oak Avenue, Los Angeles, CA 90001");
var customer3 = new CustomerInfo("Smith", "Alice", "789 Pine Road, Chicago, IL 60601");

var product1 = new Product("Laptop Computer", "LAP-001", 1299.99m);
var product2 = new Product("Wireless Mouse", "MSE-042", 29.99m);
var product3 = new Product("USB-C Cable", "CBL-256", 15.99m);
var product4 = new Product("Smartphone", "PHN-789", 899.99m);
var product5 = new Product("Screen Protector", "ACC-123", 9.99m);

// --- Insert orders ---
Console.WriteLine("--- Insert Orders ---\n");

IOrderRepository repository = new OrderRepository();

var order1 = new Order(1001, customer1);
order1.AddItem(new OrderItem(product1, 1));
order1.AddItem(new OrderItem(product2, 2));
order1.AddItem(new OrderItem(product3, 3));
repository.Insert(order1);
Console.WriteLine($"Inserted Order #{order1.Id} for {order1.CustomerInfo.FullName} (Total: ${order1.TotalCost:F2})");

var order2 = new Order(1002, customer2);
order2.AddItem(new OrderItem(product4, 1));
order2.AddItem(new OrderItem(product5, 2));
repository.Insert(order2);
Console.WriteLine($"Inserted Order #{order2.Id} for {order2.CustomerInfo.FullName} (Total: ${order2.TotalCost:F2})");

var order3 = new Order(1003, customer3);
order3.AddItem(new OrderItem(product2, 1));
order3.AddItem(new OrderItem(product5, 1));
repository.Insert(order3);
Console.WriteLine($"Inserted Order #{order3.Id} for {order3.CustomerInfo.FullName} (Total: ${order3.TotalCost:F2})");

// --- Retrieve a specific order by ID ---
Console.WriteLine("\n--- Retrieve Order by ID ---\n");

var retrieved = repository.GetById(1002);
if (retrieved != null) {
    Console.WriteLine($"Retrieved Order #{retrieved.Id} for {retrieved.CustomerInfo.FullName}");
    Console.WriteLine($"  Status: {retrieved.Status}");
    Console.WriteLine($"  Items:");
    foreach (var item in retrieved.OrderItems) {
        Console.WriteLine($"    - {item.Product.Description}: {item.Qty} x ${item.Product.UnitCost:F2} = ${item.TotalCost:F2}");
    }
    Console.WriteLine($"  Total: ${retrieved.TotalCost:F2}");
}

// --- Update an existing order ---
Console.WriteLine("\n--- Update Order ---\n");

order1.UpdateStatus(OrderStatus.Completed);
repository.Update(order1);
Console.WriteLine($"Updated Order #{order1.Id} status to: {order1.Status}");

// --- Search orders by customer name ---
Console.WriteLine("\n--- Search Orders by Customer Name ('Smith') ---\n");

var searchByName = repository.Search("Smith");
foreach (var order in searchByName) {
    Console.WriteLine($"  Found Order #{order.Id} for {order.CustomerInfo.FullName} (Status: {order.Status})");
}

// --- Search orders by ID ---
Console.WriteLine("\n--- Search Orders by ID (1003) ---\n");

var searchById = repository.Search(1003);
foreach (var order in searchById) {
    Console.WriteLine($"  Found Order #{order.Id} for {order.CustomerInfo.FullName}");
}

// --- Delete an order ---
Console.WriteLine("\n--- Delete Order ---\n");

repository.Delete(1002);
Console.WriteLine("Deleted Order #1002");

var deletedCheck = repository.GetById(1002);
string deleteResult = deletedCheck == null ? "Confirmed: Order #1002 no longer exists" : "Order #1002 still exists";
Console.WriteLine(deleteResult);

Console.WriteLine("\n=== Demo Complete ===");
