using CartQueryAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CartQueryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CartController : ControllerBase
{
    private readonly ICartRepository _cartRepository;

    public CartController(ICartRepository cartRepository)
    {
        this._cartRepository = cartRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var data = this._cartRepository.GetAll();
        return Ok(data);
    }
}