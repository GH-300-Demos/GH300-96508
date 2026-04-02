namespace MyAmazingConsole.Models;

public class OrderRepository : IOrderRepository
{
    private List<Order> orders;

    public OrderRepository()
    {
        this.orders = new List<Order>();
    }

    public void Insert(Order order)
    {
        if (order == null) {
            throw new ArgumentNullException(nameof(order), "Order cannot be null");
        }

        if (orders.Any(o => o.Id == order.Id)) {
            throw new InvalidOperationException($"An order with ID {order.Id} already exists");
        }

        orders.Add(order);
    }

    public void Update(Order order)
    {
        if (order == null) {
            throw new ArgumentNullException(nameof(order), "Order cannot be null");
        }

        int index = orders.FindIndex(o => o.Id == order.Id);
        if (index < 0) {
            throw new KeyNotFoundException($"Order with ID {order.Id} was not found");
        }

        orders[index] = order;
    }

    public void Delete(int id)
    {
        int index = orders.FindIndex(o => o.Id == id);
        if (index < 0) {
            throw new KeyNotFoundException($"Order with ID {id} was not found");
        }

        orders.RemoveAt(index);
    }

    public IEnumerable<Order> Search(string customerName)
    {
        if (string.IsNullOrWhiteSpace(customerName)) {
            throw new ArgumentException("Customer name cannot be empty", nameof(customerName));
        }

        return orders.Where(o =>
            o.CustomerInfo.FullName.Contains(customerName, StringComparison.OrdinalIgnoreCase) ||
            o.CustomerInfo.LastName.Contains(customerName, StringComparison.OrdinalIgnoreCase) ||
            o.CustomerInfo.FirstName.Contains(customerName, StringComparison.OrdinalIgnoreCase));
    }

    public IEnumerable<Order> Search(int id)
    {
        return orders.Where(o => o.Id == id);
    }

    public Order? GetById(int id)
    {
        return orders.FirstOrDefault(o => o.Id == id);
    }
}
