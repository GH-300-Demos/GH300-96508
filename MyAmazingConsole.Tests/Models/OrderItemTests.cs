using MyAmazingConsole.Models;

namespace MyAmazingConsole.Tests.Models;

public class OrderItemTests
{
    private static Product CreateProduct(decimal unitCost = 10m) =>
        new Product("Test Product", "TST-001", unitCost);

    [Theory]
    [InlineData(1)]
    [InlineData(5)]
    [InlineData(100)]
    public void Constructor_ValidQty_SetsProperties(int qty)
    {
        var product = CreateProduct();

        var item = new OrderItem(product, qty);

        Assert.Equal(product, item.Product);
        Assert.Equal(qty, item.Qty);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-100)]
    public void Constructor_InvalidQty_ThrowsArgumentException(int qty)
    {
        var product = CreateProduct();

        var ex = Assert.Throws<ArgumentException>(() => new OrderItem(product, qty));

        Assert.Equal("qty", ex.ParamName);
    }

    [Fact]
    public void Constructor_NullProduct_ThrowsArgumentNullException()
    {
        var ex = Assert.Throws<ArgumentNullException>(() => new OrderItem(null!, 1));

        Assert.Equal("product", ex.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(-50)]
    public void Qty_Setter_InvalidValue_ThrowsArgumentException(int invalidQty)
    {
        var item = new OrderItem(CreateProduct(), 1);

        var ex = Assert.Throws<ArgumentException>(() => item.Qty = invalidQty);

        Assert.Equal("value", ex.ParamName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(10)]
    [InlineData(999)]
    public void Qty_Setter_ValidValue_UpdatesQty(int newQty)
    {
        var item = new OrderItem(CreateProduct(), 1);

        item.Qty = newQty;

        Assert.Equal(newQty, item.Qty);
    }

    [Theory]
    [InlineData(10, 1, 10)]
    [InlineData(10, 3, 30)]
    [InlineData(25.50, 2, 51.00)]
    [InlineData(0.01, 1, 0.01)]
    public void TotalCost_ReturnsUnitCostTimesQty(decimal unitCost, int qty, decimal expectedTotal)
    {
        var product = CreateProduct(unitCost);
        var item = new OrderItem(product, qty);

        Assert.Equal(expectedTotal, item.TotalCost);
    }

    [Fact]
    public void Product_Setter_UpdatesProduct()
    {
        var original = CreateProduct(10m);
        var replacement = new Product("New Product", "NEW-001", 20m);
        var item = new OrderItem(original, 1);

        item.Product = replacement;

        Assert.Equal(replacement, item.Product);
    }
}
