using Microsoft.AspNetCore.Mvc;

namespace IR.DogAndCo.Api;

[ApiController]
[Route("api/[controller]")]
public sealed class ProductsController : ControllerBase
{
    [HttpGet()]
    public IActionResult Find(FindProductsIn request)
    {
        return NoContent();
    }

    [HttpGet("{code:guid}")]
    public IActionResult Get(Guid code)
    {
        return NotFound();
    }

    [HttpPut("{code:guid}")]
    public IActionResult Save(Guid code, SaveProductIn request)
    {
        return Ok();
    }

    [HttpDelete("{code:guid}")]
    public IActionResult Remove(Guid code)
    {
        return NotFound();
    }
}