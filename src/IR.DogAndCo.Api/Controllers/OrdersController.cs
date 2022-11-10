using Microsoft.AspNetCore.Mvc;

namespace IR.DogAndCo.Api;

[ApiController]
[Route("api/[controller]")]
public sealed class OrdersController : ControllerBase
{
    [HttpGet()]
    public IActionResult Find(FindOrdersIn request)
    {
        return NoContent();
    }

    [HttpGet("{code:guid}")]
    public IActionResult Get(Guid code)
    {
        return NotFound();
    }

    [HttpPut("{code:guid}")]
    public IActionResult Save(Guid code, SaveOrderIn request)
    {
        return Ok();
    }

    [HttpDelete("{code:guid}")]
    public IActionResult Remove(Guid code)
    {
        return NotFound();
    }
}