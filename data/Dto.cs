namespace data;

public class AddProductionLineDto
{
    public string Name { get; set; } = string.Empty;
    public ProductionLineStatus Status { get; set; } = ProductionLineStatus.Inactive;
    public int? CurrentOrderId { get; set; }
    public ProductionLine ToModel()
    {
        var model = new ProductionLine
        {
            Name = Name,
            Status = Status,
            CurrentOrderId = CurrentOrderId
        };
        return model;
    }
}

public class AddOrderDto
{
    public string ProductName { get; set; } = string.Empty;
    public int Quantity { get; set; } = 0;
    public Order ToModel()
    {
        var model = new Order
        {
            ProductName = ProductName,
            Quantity = Quantity
        };
        return model;
    }
}

public class AddMaterialDto
{
    public string Name { get; set; } = string.Empty;
    public int QuantityAvailable { get; set; } = 0;
    public string UnitOfMeasure { get; set; } = string.Empty;
    public Material ToModel()
    {
        var model = new Material
        {
            Name = Name,
            QuantityAvailable = QuantityAvailable,
            UnitOfMeasure = UnitOfMeasure
        };
        return model;
    }
}

public class LoginDto
{
    public string Login { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}