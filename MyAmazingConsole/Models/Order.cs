namespace MyAmazingConsole.Models;

public class Order
{
    private int id;
    private CustomerInfo customerInfo;
    private List<Product> products;
    private OrderStatus status;

    public Order(int id, CustomerInfo customerInfo)
    {
        this.id = id;
        this.customerInfo = customerInfo;
        this.products = new List<Product>();
        this.status = OrderStatus.Created;
    }

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    public CustomerInfo CustomerInfo
    {
        get { return customerInfo; }
        set { customerInfo = value; }
    }

    public List<Product> Products
    {
        get { return products; }
        set { products = value; }
    }

    public OrderStatus Status
    {
        get { return status; }
        set { status = value; }
    }

    public decimal TotalCost
    {
        get { return products.Sum(p => p.TotalCost); }
    }

    public void AddProduct(Product product)
    {
        if (product == null) {
            throw new ArgumentNullException(nameof(product), "Product cannot be null");
        }
        products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        if (product == null) {
            throw new ArgumentNullException(nameof(product), "Product cannot be null");
        }
        products.Remove(product);
    }

    public void UpdateStatus(OrderStatus newStatus)
    {
        status = newStatus;
    }
}
