namespace MyAmazingConsole.Models;

public class OrderItem
{
    private Product product;
    private int qty;

    public OrderItem(Product product, int qty)
    {
        if (product == null) {
            throw new ArgumentNullException(nameof(product), "Product cannot be null");
        }
        if (qty <= 0) {
            throw new ArgumentException("Quantity must be greater than zero", nameof(qty));
        }

        this.product = product;
        this.qty = qty;
    }

    public Product Product
    {
        get { return product; }
        set { product = value; }
    }

    public int Qty
    {
        get { return qty; }
        set {
            if (value <= 0) {
                throw new ArgumentException("Quantity must be greater than zero", nameof(value));
            }
            qty = value;
        }
    }

    public decimal TotalCost
    {
        get { return product.UnitCost * qty; }
    }
}