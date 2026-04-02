namespace MyAmazingConsole.Models;

public class CustomerInfo
{
    private string lastName;
    private string firstName;
    private string address;

    public CustomerInfo(string lastName, string firstName, string address)
    {
        this.lastName = lastName;
        this.firstName = firstName;
        this.address = address;
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public string FullName
    {
        get { return $"{firstName} {lastName}"; }
    }
}
