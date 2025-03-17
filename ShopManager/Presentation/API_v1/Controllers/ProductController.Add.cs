using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopManager.Presentation.API_v1.DataAnnotations;

namespace ShopManager.Presentation.API_v1.Controllers;

public partial class ProductController
{

    [HttpPost("add")]
    [Authorize]
    public async Task<IActionResult> AddAsync([FromForm] AddProductRequest request)
    {
        var user = await _userService.GetUserFromContext(User);
        if (user == null) return BadRequest();
        
        return Ok(user);
    }
}