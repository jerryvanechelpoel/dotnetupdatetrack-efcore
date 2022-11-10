using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace IR.DogAndCo.Api;

[ApiController]
[Route("api/[controller]")]
public sealed class CustomersController : ControllerBase
{
    private DogAndCoDbContext DbContext { get; }

    public CustomersController(DogAndCoDbContext dbContext)
    {
        DbContext = dbContext;
    }

    [HttpGet()]
    public async Task<IActionResult> Find(FindCustomersIn request)
    {
        IQueryable<CustomerEntity> query = DbContext.Customers;

        if (!string.IsNullOrEmpty(request.FirstNamePattern))
        {
            query = query.Where(entity => EF.Functions.Like(entity.FirstName, $"%{request.FirstNamePattern}%"));
        }

        if (!string.IsNullOrEmpty(request.LastNamePattern))
        {
            query = query.Where(entity => EF.Functions.Like(entity.LastName, $"%{request.LastNamePattern}%"));
        }

        if (!string.IsNullOrEmpty(request.PostalCodePattern))
        {
            query = query.Where(entity => EF.Functions.Like(entity.PostalCode, $"%{request.PostalCodePattern}%"));
        }

        var result = await query.Select(entity => new CustomerItem
        {
            Code = entity.Code,
            FirstName = entity.FirstName,
            LastName = entity.LastName,
            PostalCode = entity.PostalCode,
            AddressLine1 = entity.AddressLine
        }).ToArrayAsync();

        if (result.Length == 0)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpGet("{code:guid}")]
    public async Task<IActionResult> Get(Guid code)
    {
        CustomerDetail result = await DbContext.Customers
                                                 .Where(entity => entity.Code == code)
                                                 .Select(entity => new CustomerDetail
                                                 {
                                                     Code = entity.Code,
                                                     FirstName = entity.FirstName,
                                                     LastName = entity.LastName,
                                                     AddressLine = entity.AddressLine,
                                                     PostalCode = entity.PostalCode,
                                                     City = entity.City,
                                                     OrderHistory = entity.Orders.Select(order => order.Code).ToArray(),
                                                 })
                                                 .FirstOrDefaultAsync();

        if (result == null)
        {
            return NotFound();
        }

        return null;
    }

    [HttpPut("{code:guid}")]
    public async Task<IActionResult> Save(Guid code, SaveCustomerIn request)
    {
        CustomerEntity entity = await DbContext.Customers
                                               .FirstOrDefaultAsync(entity => entity.Code == code);

        bool isNew = entity == null;

        if (isNew)
        {
            entity = new CustomerEntity { Code = code };
            DbContext.Customers.Add(entity);
        }

        entity.FirstName = request.FirstName;
        entity.LastName = request.LastName;
        entity.AddressLine = request.AddressLine1;
        entity.PostalCode = request.PostalCode;
        entity.City = request.City;

        if (isNew)
        {
            return CreatedAtRoute($"api/customers/{code}", new CustomerDetail
            {
                Code = entity.Code,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                AddressLine = entity.AddressLine,
                PostalCode = entity.PostalCode,
                City = entity.City,
                OrderHistory = entity.Orders.Select(order => order.Code).ToArray(),
            });
        }

        return Ok();
    }
}