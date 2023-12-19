using Microsoft.AspNetCore.Mvc;
using NewProductManagement.Extensions;
using NewProductManagement.Services;

namespace NewProductManagement.Controllers;

[ApiController]
[Route("api/v1/product-filters")]
public class ProductFilterController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductFilterController(IProductService productService)
    {
        _productService = productService;
    }
    
    // GET endpoint to retrieve products by name.
    [HttpGet("list")]
    public IActionResult GetByName([FromQuery] string name)
    {
        var productsByName = _productService.GetProductsByName(name);
        return Ok(productsByName);
    }
    
    [HttpGet("filter-by-genre")]
    public IActionResult FilterByGenre([FromQuery] int genreId)
    {
        var products = _productService.GetProducts();
        var filteredProducts = products.FilterByGenre(genreId); 
        return Ok(filteredProducts);
    }
}