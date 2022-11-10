using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IR.DogAndCo.Api.Infrastructure.Database.Configuration;

public sealed class CustomerEntityConfiguration : IEntityTypeConfiguration<CustomerEntity>
{
    public void Configure(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder.ToTable("Customer", SchemaConstant.SchemaName);

        builder.HasMany(customer => customer.Orders)
               .WithOne(order => order.Customer);
    }
}