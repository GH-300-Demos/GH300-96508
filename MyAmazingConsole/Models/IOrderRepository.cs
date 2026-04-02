namespace MyAmazingConsole.Models;

public interface IOrderRepository
{
    void Insert(Order order);
    void Update(Order order);
    void Delete(int id);
    IEnumerable<Order> Search(string customerName);
    IEnumerable<Order> Search(int id);
    Order? GetById(int id);
}
