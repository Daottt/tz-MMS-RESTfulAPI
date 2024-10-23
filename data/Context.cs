using Microsoft.EntityFrameworkCore;

namespace data;

public class Context: DbContext
{
    public Context(DbContextOptions<Context> options): base(options) {}
    public DbSet<Order> Orders { get; set; } = null!;
    public DbSet<Material> Materials { get; set; } = null!;
    public DbSet<ProductionLine> ProductionLines{ get; set; } = null!;
    public DbSet<User> Users{ get; set; } = null!;
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProductionLineConfiguration());
        modelBuilder.ApplyConfiguration(new OrderConfiguration());
        modelBuilder.Entity<User>().HasData(new User { Id = 1 , Login = "user", Password = "password"});
        base.OnModelCreating(modelBuilder);
    }
}
