using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IR.DogAndCo.Api.Infrastructure.Database.Configuration;

public sealed class ProductTypeEntityConfiguration : IEntityTypeConfiguration<ProductTypeEntity>
{
    public void Configure(EntityTypeBuilder<ProductTypeEntity> builder)
    { 
        builder.ToTable("ProductType", SchemaConstant.SchemaName);

        builder.HasKey(productType => productType.Id);

        builder.HasMany(productType => productType.Products)
               .WithOne(product => product.ProductType);
    }
}
