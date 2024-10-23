namespace data;

public enum OrderStatus
{
    Pending,
    InProgress,
    Completed,
    Canceled
}
public enum ProductionLineStatus
{
    Active,
    Inactive
}

public class Order
{
    public int Id { get; set; } 
    public string ProductName{ get; set; } = string.Empty;
    public int Quantity { get; set; } = 0;
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public DateTime CreatedAt { get; set; }
    public List<Material> UsedMaterials { get; set; } = new List<Material>();
}

public class Material
{
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public int QuantityAvailable { get; set; } = 0;
    public string UnitOfMeasure { get; set; } = string.Empty;
    public List<Order> UsedInOrders { get; set; } = new List<Order>();
}

public class ProductionLine
{
    public int Id { get; set; } 
    public string Name { get; set; } = string.Empty;
    public ProductionLineStatus Status { get; set; } = ProductionLineStatus.Inactive;
    public int? CurrentOrderId { get; set; }
    public Order? CurrentOrder { get; set; }
}

public class User
{
    public int Id { get; set; }
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}