using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace IR.DogAndCo.Api.Tests
{
    public class CustomerControllerTests
    {
        public DogAndCoDbContext DbContext { get; }

        public CustomerControllerTests()
        {
            SqliteConnection connection = new("Filename=:memory:");
            connection.Open();

            DbContextOptionsBuilder<DogAndCoDbContext> optionsBuilder = new();
            optionsBuilder.UseSqlite(connection);

            DbContext = new DogAndCoDbContext(null);

            DbContext.Database.EnsureDeleted();
            DbContext.Database.EnsureCreated();
        }

        [Fact]
        public async Task Get_Test()
        {
            Guid code = Guid.NewGuid();
            DbContext.Customers.Add(new CustomerEntity { Id = 1, Code = code, FirstName = "Homer", LastName = "Simpson", AddressLine = "742 Evergreen Terrace", PostalCode = "58008", City = "Springfield" });

            await DbContext.SaveChangesAsync();

            CustomersController sut = new(DbContext);

            OkObjectResult result = (await sut.Get(code)) as OkObjectResult;
            Assert.NotNull(result);

            CustomerDetail customer = result.Value as CustomerDetail;
            Assert.NotNull(customer);
            Assert.Equal("Homer", customer.FirstName);
        }
    }
}