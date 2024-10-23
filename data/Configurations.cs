using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace data;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.Property(o => o.Status).HasConversion(s => s.ToString(), s => Enum.Parse<OrderStatus>(s));
        builder
            .HasMany(o => o.UsedMaterials)
            .WithMany(m => m.UsedInOrders);
    }
}
public class ProductionLineConfiguration : IEntityTypeConfiguration<ProductionLine>
{
    public void Configure(EntityTypeBuilder<ProductionLine> builder)
    {
        builder.HasKey(p  => p.Id);
        builder.HasOne(p => p.CurrentOrder);
        builder.Property(p => p.Status).HasConversion(s => s.ToString(), s => Enum.Parse<ProductionLineStatus>(s));
    }
}