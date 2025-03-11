using Microsoft.AspNetCore.Mvc;
using ShopManager.Infrastructure.Interfaces;
using ShopManager.Infrastructure.Services;

namespace ShopManager.Presentation.API_v1.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class AuthController : ControllerBase
{
    private readonly IBaseRepository _baseRepository;

    public AuthController(IBaseRepository baseRepository)
    {
        _baseRepository = baseRepository;
    }
}