namespace MyAmazingConsole.Models;

public class Order
{
    private int id;
    private CustomerInfo customerInfo;
    private List<OrderItem> orderItems;
    private OrderStatus status;

    public Order(int id, CustomerInfo customerInfo)
    {
        if (id <= 0) {
            throw new ArgumentException("Order ID must be greater than zero", nameof(id));
        }

        this.id = id;
        this.customerInfo = customerInfo;
        this.orderItems = new List<OrderItem>();
        this.status = OrderStatus.Created;
    }

    public int Id
    {
        get { return id; }
        set {
            if (value <= 0) {
                throw new ArgumentException("Order ID must be greater than zero", nameof(value));
            }
            id = value;
        }
    }

    public CustomerInfo CustomerInfo
    {
        get { return customerInfo; }
        set { customerInfo = value; }
    }

    public List<OrderItem> OrderItems
    {
        get { return orderItems; }
        set { orderItems = value; }
    }

    public OrderStatus Status
    {
        get { return status; }
        set { status = value; }
    }

    public decimal TotalCost
    {
        get { return orderItems.Sum(item => item.TotalCost); }
    }

    public void AddItem(OrderItem orderItem)
    {
        if (orderItem == null) {
            throw new ArgumentNullException(nameof(orderItem), "Order item cannot be null");
        }

        orderItems.Add(orderItem);
    }

    public void RemoveItem(OrderItem orderItem)
    {
        if (orderItem == null) {
            throw new ArgumentNullException(nameof(orderItem), "Order item cannot be null");
        }

        orderItems.Remove(orderItem);
    }

    public void UpdateStatus(OrderStatus newStatus)
    {
        status = newStatus;
    }
}
