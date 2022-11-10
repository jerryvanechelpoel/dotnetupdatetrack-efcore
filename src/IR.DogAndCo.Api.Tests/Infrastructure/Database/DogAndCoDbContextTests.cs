using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace IR.DogAndCo.Api.Tests
{
    public sealed class DogAndCoDbContextFixture
    {
        public DogAndCoDbContext DbContext { get; }

        public DogAndCoDbContextFixture()
        {
            IConfiguration config = new ConfigurationBuilder()
                                            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                                            .AddJsonFile("testsettings.json")
                                            .Build();
            DbContextOptionsBuilder<DogAndCoDbContext> optionsBuilder = new ();
            optionsBuilder.UseSqlServer(config.GetConnectionString("DogAndCoDbContext"));

            DbContext = new DogAndCoDbContext(optionsBuilder.Options) ;
        }
    }

    public sealed class DogAndCoDbContextTests : IClassFixture<DogAndCoDbContextFixture>
    {
        private DogAndCoDbContextFixture Fixture { get; }

        public DogAndCoDbContextTests(DogAndCoDbContextFixture fixture)
        {
            Fixture = fixture;
        }

        [Fact]
        public async Task Customers_Test()
            => await Fixture.DbContext.Customers.Take(10).ToArrayAsync();

        [Fact]
        public async Task Orders_Test()
            => await Fixture.DbContext.Orders.Take(10).ToArrayAsync();

        [Fact]
        public async Task Products_Test()
            => await Fixture.DbContext.Products.Take(10).ToArrayAsync();

        [Fact]
        public async Task ProductTypes_Test()
            => await Fixture.DbContext.ProductTypes.Take(10).ToArrayAsync();

        [Fact]
        public async Task Promotions_Test()
            => await Fixture.DbContext.Promotions.Take(10).ToArrayAsync();

        [Fact]
        public async Task Top10Customers_test()
            => await Fixture.DbContext.Top10Customers().ToArrayAsync();
    }
}