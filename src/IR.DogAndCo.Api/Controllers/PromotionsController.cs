using Microsoft.AspNetCore.Mvc;

namespace IR.DogAndCo.Api;

[ApiController]
[Route("api/[controller]")]
public sealed class PromotionsController : ControllerBase
{
    [HttpGet()]
    public IActionResult Find(FindPromotionsIn request)
    {
        return NoContent();
    }

    [HttpGet("{code:guid}")]
    public IActionResult Get(Guid code)
    {
        return NotFound();
    }

    [HttpPut("{code:guid}")]
    public IActionResult Save(Guid code, SavePromotionIn request)
    {
        return Ok();
    }

    [HttpDelete("{code:guid}")]
    public IActionResult Remove(Guid code)
    {
        return NotFound();
    }
}