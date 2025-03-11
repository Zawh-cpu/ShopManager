using Microsoft.AspNetCore.Mvc;

namespace ShopManager.Presentation.API_v1.Controllers;

public partial class TestController
{
    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok();
    }
}