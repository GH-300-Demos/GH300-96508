using MyAmazingConsole.Models;

namespace MyAmazingConsole.Tests.Models;

public class OrderTests
{
    private static CustomerInfo CreateCustomer() =>
        new CustomerInfo("Smith", "John", "123 Main St");

    private static Product CreateProduct(decimal unitCost = 10m) =>
        new Product("Test Product", "TST-001", unitCost);

    [Theory]
    [InlineData(1)]
    [InlineData(100)]
    [InlineData(int.MaxValue)]
    public void Constructor_ValidId_SetsProperties(int id)
    {
        var customer = CreateCustomer();

        var order = new Order(id, customer);

        Assert.Equal(id, order.Id);
        Assert.Equal(customer, order.CustomerInfo);
        Assert.Empty(order.OrderItems);
        Assert.Equal(OrderStatus.Created, order.Status);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void Constructor_InvalidId_ThrowsArgumentException(int id)
    {
        var ex = Assert.Throws<ArgumentException>(() => new Order(id, CreateCustomer()));

        Assert.Equal("id", ex.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    [InlineData(int.MinValue)]
    public void Id_Setter_InvalidValue_ThrowsArgumentException(int invalidId)
    {
        var order = new Order(1, CreateCustomer());

        var ex = Assert.Throws<ArgumentException>(() => order.Id = invalidId);

        Assert.Equal("value", ex.ParamName);
    }

    [Theory]
    [InlineData(1)]
    [InlineData(500)]
    public void Id_Setter_ValidValue_UpdatesId(int newId)
    {
        var order = new Order(1, CreateCustomer());

        order.Id = newId;

        Assert.Equal(newId, order.Id);
    }

    [Fact]
    public void AddItem_ValidItem_AddsToOrderItems()
    {
        var order = new Order(1, CreateCustomer());
        var item = new OrderItem(CreateProduct(), 2);

        order.AddItem(item);

        Assert.Single(order.OrderItems);
        Assert.Contains(item, order.OrderItems);
    }

    [Fact]
    public void AddItem_MultipleItems_AddsAll()
    {
        var order = new Order(1, CreateCustomer());
        var item1 = new OrderItem(CreateProduct(), 1);
        var item2 = new OrderItem(CreateProduct(20m), 3);

        order.AddItem(item1);
        order.AddItem(item2);

        Assert.Equal(2, order.OrderItems.Count);
    }

    [Fact]
    public void AddItem_NullItem_ThrowsArgumentNullException()
    {
        var order = new Order(1, CreateCustomer());

        var ex = Assert.Throws<ArgumentNullException>(() => order.AddItem(null!));

        Assert.Equal("orderItem", ex.ParamName);
    }

    [Fact]
    public void RemoveItem_ExistingItem_RemovesFromOrderItems()
    {
        var order = new Order(1, CreateCustomer());
        var item = new OrderItem(CreateProduct(), 2);
        order.AddItem(item);

        order.RemoveItem(item);

        Assert.Empty(order.OrderItems);
    }

    [Fact]
    public void RemoveItem_NonExistentItem_DoesNothing()
    {
        var order = new Order(1, CreateCustomer());
        var item1 = new OrderItem(CreateProduct(), 1);
        var item2 = new OrderItem(CreateProduct(20m), 1);
        order.AddItem(item1);

        order.RemoveItem(item2);

        Assert.Single(order.OrderItems);
    }

    [Fact]
    public void RemoveItem_NullItem_ThrowsArgumentNullException()
    {
        var order = new Order(1, CreateCustomer());

        var ex = Assert.Throws<ArgumentNullException>(() => order.RemoveItem(null!));

        Assert.Equal("orderItem", ex.ParamName);
    }

    [Fact]
    public void TotalCost_NoItems_ReturnsZero()
    {
        var order = new Order(1, CreateCustomer());

        Assert.Equal(0m, order.TotalCost);
    }

    [Fact]
    public void TotalCost_WithItems_ReturnsSumOfItemTotalCosts()
    {
        var order = new Order(1, CreateCustomer());
        order.AddItem(new OrderItem(CreateProduct(10m), 2));   // 20
        order.AddItem(new OrderItem(CreateProduct(5.50m), 3)); // 16.50

        Assert.Equal(36.50m, order.TotalCost);
    }

    [Theory]
    [InlineData(OrderStatus.Created)]
    [InlineData(OrderStatus.Completed)]
    [InlineData(OrderStatus.Shipped)]
    [InlineData(OrderStatus.Closed)]
    [InlineData(OrderStatus.Deleted)]
    public void UpdateStatus_SetsNewStatus(OrderStatus newStatus)
    {
        var order = new Order(1, CreateCustomer());

        order.UpdateStatus(newStatus);

        Assert.Equal(newStatus, order.Status);
    }

    [Fact]
    public void CustomerInfo_Setter_UpdatesCustomer()
    {
        var order = new Order(1, CreateCustomer());
        var newCustomer = new CustomerInfo("Doe", "Jane", "456 Oak Ave");

        order.CustomerInfo = newCustomer;

        Assert.Equal(newCustomer, order.CustomerInfo);
    }
}
