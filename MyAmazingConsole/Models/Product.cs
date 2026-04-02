namespace MyAmazingConsole.Models;

public class Product
{
    private string description;
    private string code;
    private decimal unitCost;

    public Product(string description, string code, decimal unitCost)
    {
        if (unitCost <= 0) {
            throw new ArgumentException("Unit cost must be greater than zero", nameof(unitCost));
        }

        this.description = description;
        this.code = code;
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

    public decimal UnitCost
    {
        get { return unitCost; }
        set {
            if (value <= 0) {
                throw new ArgumentException("Unit cost must be greater than zero", nameof(value));
            }
            unitCost = value;
        }
    }
}
