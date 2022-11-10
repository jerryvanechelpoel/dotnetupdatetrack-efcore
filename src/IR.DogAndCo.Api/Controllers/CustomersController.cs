using Microsoft.AspNetCore.Mvc;

namespace IR.DogAndCo.Api;

[ApiController]
[Route("api/[controller]")]
public sealed class CustomersController : ControllerBase
{
    [HttpGet()]
    public IActionResult Find(FindCustomersIn request)
    {
        return NoContent();
    }

    [HttpGet("{code:guid}")]
    public IActionResult Get(Guid code)
    {
        return NotFound();
    }

    [HttpPut("{code:guid}")]
    public IActionResult Save(Guid code, SaveCustomerIn request)
    {
        return Ok();
    }

    [HttpDelete("{code:guid}")]
    public IActionResult Remove(Guid code)
    {
        return NotFound();
    }
}