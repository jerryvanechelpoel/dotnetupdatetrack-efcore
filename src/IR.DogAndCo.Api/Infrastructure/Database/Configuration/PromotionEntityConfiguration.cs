using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IR.DogAndCo.Api.Infrastructure.Database.Configuration;

public sealed class PromotionEntityConfiguration : IEntityTypeConfiguration<PromotionEntity>
{
    public void Configure(EntityTypeBuilder<PromotionEntity> builder)
    {
        builder.ToTable("Promotion", SchemaConstant.SchemaName);

        builder.HasMany(promotion => promotion.Products)
               .WithMany(product => product.Promotions)
               .UsingEntity<Dictionary<string, object>>(
                    "ProductPromotion",
                    promotion => promotion.HasOne<ProductEntity>()
                                      .WithMany()
                                      .HasForeignKey("ProductId")
                                      .HasConstraintName("FK_ProductPromotion_Product")
                                      .OnDelete(DeleteBehavior.Cascade),
                    product => product.HasOne<PromotionEntity>()
                                      .WithMany()
                                      .HasForeignKey("PromotionId")
                                      .HasConstraintName("FK_ProductPromotion_Promotion")
                                      .OnDelete(DeleteBehavior.ClientCascade));
    }
}