using MyAmazingConsole.Models;

namespace MyAmazingConsole.Tests.Models;

public class CustomerInfoTests
{
    [Theory]
    [InlineData("Smith", "John", "123 Main St")]
    [InlineData("Doe", "Jane", "456 Oak Ave")]
    [InlineData("", "", "")]
    public void Constructor_SetsProperties(string lastName, string firstName, string address)
    {
        var customer = new CustomerInfo(lastName, firstName, address);

        Assert.Equal(lastName, customer.LastName);
        Assert.Equal(firstName, customer.FirstName);
        Assert.Equal(address, customer.Address);
    }

    [Theory]
    [InlineData("Smith", "John", "John Smith")]
    [InlineData("Doe", "Jane", "Jane Doe")]
    [InlineData("", "", " ")]
    [InlineData("O'Brien", "Mary", "Mary O'Brien")]
    public void FullName_ReturnsFirstNameSpaceLastName(string lastName, string firstName, string expected)
    {
        var customer = new CustomerInfo(lastName, firstName, "address");

        Assert.Equal(expected, customer.FullName);
    }

    [Fact]
    public void LastName_SetterUpdatesValue()
    {
        var customer = new CustomerInfo("Smith", "John", "123 Main St");

        customer.LastName = "Jones";

        Assert.Equal("Jones", customer.LastName);
    }

    [Fact]
    public void FirstName_SetterUpdatesValue()
    {
        var customer = new CustomerInfo("Smith", "John", "123 Main St");

        customer.FirstName = "Jane";

        Assert.Equal("Jane", customer.FirstName);
    }

    [Fact]
    public void Address_SetterUpdatesValue()
    {
        var customer = new CustomerInfo("Smith", "John", "123 Main St");

        customer.Address = "789 Elm St";

        Assert.Equal("789 Elm St", customer.Address);
    }

    [Fact]
    public void FullName_ReflectsUpdatedNames()
    {
        var customer = new CustomerInfo("Smith", "John", "123 Main St");

        customer.FirstName = "Jane";
        customer.LastName = "Doe";

        Assert.Equal("Jane Doe", customer.FullName);
    }
}
