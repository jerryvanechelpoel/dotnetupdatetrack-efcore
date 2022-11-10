using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IR.DogAndCo.Api.Infrastructure.Database.Configuration;

public sealed class OrderLineEntityConfiguration : IEntityTypeConfiguration<OrderLineEntity>
{
    public void Configure(EntityTypeBuilder<OrderLineEntity> builder)
    {
        builder.ToTable("OrderLine", SchemaConstant.SchemaName);

        builder.HasOne(orderLine => orderLine.Order)
               .WithMany(order => order.OrderLines);

        builder.HasOne(orderLine => orderLine.Product)
               .WithMany();
    }
}
