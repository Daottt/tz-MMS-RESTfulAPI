using data;
using data.Repositories;

namespace Tests;

public class MaterialRepositoryTest : TestRepositoryBase
{
    [Fact]
    public void GetMaterial_Success()
    {
        // Arrange
        var repository = new MaterialRepository(Context);
        // Act
        var material = repository.Get(1);
        // Assert
        Assert.NotNull(material);
    }
    [Fact]
    public void CreateMaterial_Success()
    {
        // Arrange
        var repository = new MaterialRepository(Context);
        var material = new Material
        {
            Name = "name",
            QuantityAvailable = 1,
            UnitOfMeasure = "unit"
        };
        // Act
        repository.Create(material);
        // Assert
        Assert.NotNull(Context.Materials.Find(material.Id));
    }
    [Fact]
    public void UpdateMaterial_Success()
    {
        // Arrange
        var repository = new MaterialRepository(Context);
        var newQuantity = 4;
        // Act
        repository.UpdateQuantity(1, newQuantity);
        // Assert
        Assert.NotNull(Context.Materials.FirstOrDefault(o => o.Id == 1 && o.QuantityAvailable == newQuantity));
    }
    [Fact]
    public void DeleteMaterial_Success()
    {
        // Arrange
        var repository = new MaterialRepository(Context);
        // Act
        repository.Delete(1);
        // Assert
        Assert.Null(Context.Materials.Find(1));
    }
}