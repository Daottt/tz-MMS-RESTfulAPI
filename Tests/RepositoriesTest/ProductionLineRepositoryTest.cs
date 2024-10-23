using data;
using data.Repositories;

namespace Tests;

public class ProductionLineRepositoryTest : TestRepositoryBase
{
    [Fact]
    public void GetProductionLine_Success()
    {
        // Arrange
        var repository = new ProductionLineRepository(Context);
        // Act
        var line = repository.Get(1);
        // Assert
        Assert.NotNull(line);
    }
    [Fact]
    public void CreateProductionLine_Success()
    {
        // Arrange
        var repository = new ProductionLineRepository(Context);
        var line = new ProductionLine
        {
            Name = "name",
            Status = ProductionLineStatus.Inactive
        };
        // Act
        repository.Create(line);
        // Assert
        Assert.NotNull(Context.ProductionLines.Find(line.Id));
    }
    [Fact]
    public void UpdateProductionLine_Success()
    {
        // Arrange
        var repository = new ProductionLineRepository(Context);
        var newStatus = ProductionLineStatus.Inactive;
        // Act
        repository.UpdateStaus(1, newStatus);
        // Assert
        Assert.NotNull(Context.ProductionLines.FirstOrDefault(o => o.Id == 1 && o.Status == newStatus));
    }
    [Fact]
    public void DeleteProductionLine_Success()
    {
        // Arrange
        var repository = new ProductionLineRepository(Context);
        // Act
        repository.Delete(1);
        // Assert
        Assert.Null(Context.ProductionLines.Find(1));
    }
}