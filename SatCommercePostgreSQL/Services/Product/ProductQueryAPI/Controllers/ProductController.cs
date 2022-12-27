using Microsoft.AspNetCore.Mvc;
using ProductQueryAPI.Models;
using ProductQueryAPI.Repositories;

namespace ProductQueryAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _productRepository;

    public ProductController(IProductRepository productRepository)
    {
        this._productRepository = productRepository;
    }
    
    [HttpGet]
    public IActionResult GetAllData()
    {
        var data = this._productRepository.GetAll();
        return Ok(data);
    }

    [HttpGet("{slug}")]
    public ActionResult<Product> GetSpecific(string slug)
    {
        return this._productRepository.GetBySlug(slug);
    }
}