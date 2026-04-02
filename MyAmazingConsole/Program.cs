using MyAmazingConsole.Models;

Console.WriteLine("=== E-Commerce Order Management Demo ===\n");

// Create customer information
var customer1 = new CustomerInfo("Smith", "John", "123 Main Street, New York, NY 10001");
var customer2 = new CustomerInfo("Johnson", "Emma", "456 Oak Avenue, Los Angeles, CA 90001");

// Create first order
var order1 = new Order(1001, customer1);
Console.WriteLine($"Created Order #{order1.Id} for {order1.CustomerInfo.FullName}");
Console.WriteLine($"Initial Status: {order1.Status}");

// Create products and order items for order 1
var product1 = new Product("Laptop Computer", "LAP-001", 1299.99m);
var product2 = new Product("Wireless Mouse", "MSE-042", 29.99m);
var product3 = new Product("USB-C Cable", "CBL-256", 15.99m);

var orderItem1 = new OrderItem(product1, 1);
var orderItem2 = new OrderItem(product2, 2);
var orderItem3 = new OrderItem(product3, 3);

order1.AddItem(orderItem1);
order1.AddItem(orderItem2);
order1.AddItem(orderItem3);

Console.WriteLine($"\nItems in Order #{order1.Id}:");
foreach (var orderItem in order1.OrderItems) {
    Console.WriteLine($"  - {orderItem.Product.Description} ({orderItem.Product.Code}): {orderItem.Qty} x ${orderItem.Product.UnitCost:F2} = ${orderItem.TotalCost:F2}");
}

Console.WriteLine($"\nOrder Total: ${order1.TotalCost:F2}");

// Update order status
order1.UpdateStatus(OrderStatus.Completed);
Console.WriteLine($"Updated Status: {order1.Status}");

// Create second order
Console.WriteLine("\n" + new string('-', 60) + "\n");
var order2 = new Order(1002, customer2);
Console.WriteLine($"Created Order #{order2.Id} for {order2.CustomerInfo.FullName}");
Console.WriteLine($"Address: {order2.CustomerInfo.Address}");

// Create products and order items for order 2
var product4 = new Product("Smartphone", "PHN-789", 899.99m);
var product5 = new Product("Screen Protector", "ACC-123", 9.99m);

var orderItem4 = new OrderItem(product4, 1);
var orderItem5 = new OrderItem(product5, 2);

order2.AddItem(orderItem4);
order2.AddItem(orderItem5);

Console.WriteLine($"\nItems in Order #{order2.Id}:");
foreach (var orderItem in order2.OrderItems) {
    Console.WriteLine($"  - {orderItem.Product.Description} ({orderItem.Product.Code}): {orderItem.Qty} x ${orderItem.Product.UnitCost:F2} = ${orderItem.TotalCost:F2}");
}

Console.WriteLine($"\nOrder Total: ${order2.TotalCost:F2}");

// Demonstrate status transitions
order2.UpdateStatus(OrderStatus.Completed);
Console.WriteLine($"\nOrder #{order2.Id} Status: {order2.Status}");

order2.UpdateStatus(OrderStatus.Shipped);
Console.WriteLine($"Order #{order2.Id} Status: {order2.Status}");

order2.UpdateStatus(OrderStatus.Closed);
Console.WriteLine($"Order #{order2.Id} Status: {order2.Status}");

Console.WriteLine("\n=== Demo Complete ===");
