using Microsoft.EntityFrameworkCore;

namespace IR.DogAndCo.Api;

public sealed class DogAndCoDbContext : DbContext
{
    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductTypeEntity> ProductTypes { get; set; }
    public DbSet<PromotionEntity> Promotions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
