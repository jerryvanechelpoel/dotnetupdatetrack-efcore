using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IR.DogAndCo.Api.Infrastructure.Database.Configuration;

public sealed class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
{
    public void Configure(EntityTypeBuilder<ProductEntity> builder)
    {
        builder.ToTable("Product", SchemaConstant.SchemaName);

        builder.HasOne(product => product.ProductType)
               .WithMany(productType => productType.Products);

        builder.HasMany(product => product.Promotions)
               .WithMany(promotion => promotion.Products)
               .UsingEntity<Dictionary<string, object>>(
                    "ProductPromotion",
                    product => product.HasOne<PromotionEntity>()
                                      .WithMany()
                                      .HasForeignKey("PromotionId")
                                      .HasConstraintName("FK_ProductPromotion_Promotion")
                                      .OnDelete(DeleteBehavior.Cascade),
                    promotion => promotion.HasOne<ProductEntity>()
                                      .WithMany()
                                      .HasForeignKey("ProductId")
                                      .HasConstraintName("FK_ProductPromotion_Product")
                                      .OnDelete(DeleteBehavior.ClientCascade));
    }
}
