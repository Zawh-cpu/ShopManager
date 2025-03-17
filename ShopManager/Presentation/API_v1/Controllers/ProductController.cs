using Microsoft.AspNetCore.Mvc;
using ShopManager.Core.Interfaces;

namespace ShopManager.Presentation.API_v1.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class ProductController : ControllerBase
{
    private readonly IBaseRepository _baseRepository;
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public ProductController(IBaseRepository baseRepository, IUserService userService, ITokenService tokenService)
    {
        _baseRepository = baseRepository;
        _userService = userService;
    }
}