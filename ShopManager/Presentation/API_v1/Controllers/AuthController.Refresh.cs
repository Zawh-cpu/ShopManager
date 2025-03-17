using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopManager.Core.Entities;
using ShopManager.Presentation.API_v1.DataAnnotations;

namespace ShopManager.Presentation.API_v1.Controllers;

public partial class AuthController
{
    [HttpGet("refresh")]
    [Authorize]
    public async Task<IActionResult> Refresh()
    {
        if (!Guid.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out Guid userId)) return BadRequest();

        var token = _tokenService.GenerateToken(userId, TokenType.Action);
        await _baseRepository.AddEntityAsync(token);
        
        return new OkObjectResult(new
        {
            UserId = userId,
            ActionToken = token.TokenData,
        });
    }
}