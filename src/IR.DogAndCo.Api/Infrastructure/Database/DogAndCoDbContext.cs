using Microsoft.EntityFrameworkCore;

namespace IR.DogAndCo.Api;

public sealed partial class DogAndCoDbContext : DbContext
{
    public DogAndCoDbContext(DbContextOptions<DogAndCoDbContext> options)
        : base(options)
    { }

    public DbSet<CustomerEntity> Customers { get; set; }
    public DbSet<OrderEntity> Orders { get; set; }
    public DbSet<ProductEntity> Products { get; set; }
    public DbSet<ProductTypeEntity> ProductTypes { get; set; }
    public DbSet<PromotionEntity> Promotions { get; set; }

    public IQueryable<CustomerEntity> Top10Customers()
        => Customers.FromSqlRaw(QueryStore.Top10CustomersQuery);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}
