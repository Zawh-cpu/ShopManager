using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShopManager.Presentation.API_v1.Controllers;

public partial class UserController
{

    [HttpGet("me")]
    [Authorize]
    public async Task<IActionResult> GetMeAsync()
    {
        var user = await _userService.GetUserFromContext(User);
        if (user == null) return BadRequest();
        
        return Ok(user);
    }
}