namespace MyAmazingConsole.Models;

public class Product
{
    private string description;
    private string code;
    private int qty;
    private decimal unitCost;

    public Product(string description, string code, int qty, decimal unitCost)
    {
        this.description = description;
        this.code = code;
        this.qty = qty;
        this.unitCost = unitCost;
    }

    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    public string Code
    {
        get { return code; }
        set { code = value; }
    }

    public int Qty
    {
        get { return qty; }
        set { qty = value; }
    }

    public decimal UnitCost
    {
        get { return unitCost; }
        set { unitCost = value; }
    }

    public decimal TotalCost
    {
        get { return qty * unitCost; }
    }
}
