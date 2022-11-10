using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IR.DogAndCo.Api.Infrastructure.Database.Configuration;

public sealed class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
{
    public void Configure(EntityTypeBuilder<OrderEntity> builder)
    { 
        builder.ToTable("Order", SchemaConstant.SchemaName);

        builder.HasOne(order => order.Customer)
               .WithMany(customer => customer.Orders);

        builder.HasMany(order => order.OrderLines)
               .WithOne(orderLine => orderLine.Order);
    }
}
