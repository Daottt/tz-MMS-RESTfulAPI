using Microsoft.EntityFrameworkCore;
using data;

namespace Tests;

public class ContextFactory
{
    public static Context Create()
    {
        var options = new DbContextOptionsBuilder<Context>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new Context(options);
        context.Database.EnsureCreated();
        context.AddRange(
            new Material
            {
                Id = 1,
                Name = "Material1",
                QuantityAvailable = 1,
                UnitOfMeasure = "Mesure1"
            },
            new Order
            {
                Id = 1,
                ProductName = "Product1",
                Quantity = 1,
                Status = OrderStatus.Pending,
                CreatedAt = new DateTime()
            },
            new ProductionLine
            {
                Id = 1,
                Name = "Line1",
                Status = ProductionLineStatus.Active
            }
            );
        context.SaveChanges();
        return context;
    }
    public static void Destroy(Context context)
    {
        context.Database.EnsureDeleted();
        context.Dispose();
    }
}
