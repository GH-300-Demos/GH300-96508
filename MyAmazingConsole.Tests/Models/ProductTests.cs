using MyAmazingConsole.Models;

namespace MyAmazingConsole.Tests.Models;

public class ProductTests
{
    [Theory]
    [InlineData("Laptop", "LAP-001", 1299.99)]
    [InlineData("Mouse", "MSE-042", 0.01)]
    [InlineData("Cable", "CBL-256", 1)]
    public void Constructor_ValidUnitCost_SetsProperties(string description, string code, decimal unitCost)
    {
        var product = new Product(description, code, unitCost);

        Assert.Equal(description, product.Description);
        Assert.Equal(code, product.Code);
        Assert.Equal(unitCost, product.UnitCost);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-0.01)]
    public void Constructor_InvalidUnitCost_ThrowsArgumentException(decimal unitCost)
    {
        var ex = Assert.Throws<ArgumentException>(() => new Product("Laptop", "LAP-001", unitCost));

        Assert.Equal("unitCost", ex.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100.50)]
    public void UnitCost_Setter_InvalidValue_ThrowsArgumentException(decimal invalidCost)
    {
        var product = new Product("Laptop", "LAP-001", 10m);

        var ex = Assert.Throws<ArgumentException>(() => product.UnitCost = invalidCost);

        Assert.Equal("value", ex.ParamName);
    }

    [Theory]
    [InlineData(0.01)]
    [InlineData(1)]
    [InlineData(9999.99)]
    public void UnitCost_Setter_ValidValue_UpdatesCost(decimal newCost)
    {
        var product = new Product("Laptop", "LAP-001", 10m);

        product.UnitCost = newCost;

        Assert.Equal(newCost, product.UnitCost);
    }

    [Fact]
    public void Description_Setter_UpdatesValue()
    {
        var product = new Product("Laptop", "LAP-001", 10m);

        product.Description = "Desktop";

        Assert.Equal("Desktop", product.Description);
    }

    [Fact]
    public void Code_Setter_UpdatesValue()
    {
        var product = new Product("Laptop", "LAP-001", 10m);

        product.Code = "DSK-001";

        Assert.Equal("DSK-001", product.Code);
    }
}
