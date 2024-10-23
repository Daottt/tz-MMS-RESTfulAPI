using data;
using data.Repositories;

namespace Tests;

public class OrderRepositoryTest: TestRepositoryBase
{
    [Fact]
    public void GetOrder_Success()
    {
        // Arrange
        var repository = new OrderRepository(Context);
        // Act
        var order = repository.Get(1);
        // Assert
        Assert.NotNull(order);
    }
    [Fact]
    public void CreateOrder_Success()
    {
        // Arrange
        var repository = new OrderRepository(Context);
        var order = new Order
        {
            ProductName = "name",
            Quantity = 1,
        };
        // Act
        repository.Create(order);
        // Assert
        Assert.NotNull(Context.Orders.Find(order.Id));
    }
    [Fact]
    public void UpdateOrder_Success() 
    {
        // Arrange
        var repository = new OrderRepository(Context);
        var newStatus = OrderStatus.InProgress;
        // Act
        repository.UpdateStaus(1, newStatus);
        // Assert
        Assert.NotNull(Context.Orders.FirstOrDefault(o => o.Id == 1 && o.Status == newStatus));
    }
    [Fact]
    public void DeleteOrder_Success() 
    {
        // Arrange
        var repository = new OrderRepository(Context);
        // Act
        repository.Delete(1);
        // Assert
        Assert.Null(Context.Orders.Find(1));
    }
}