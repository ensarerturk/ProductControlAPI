using Microsoft.AspNetCore.Mvc;
using NewProductManagement.Extensions;
using NewProductManagement.Models;
using NewProductManagement.Services;

namespace NewProductManagement.Controllers;

[ApiController]
[Route("api/v1/product-sorts")]
public class ProductSortController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductSortController(IProductService productService)
    {
        _productService = productService;
    }
    
    // GET endpoint to retrieve sorted products by name.
    [HttpGet("list-sorted")]
    public IActionResult GetByNameAndSort([FromQuery] string name, [FromQuery] string sort)
    {
        var productsByNameAndSort = _productService.GetProductsByNameAndSort(name, sort);
        return Ok(productsByNameAndSort);
    }
    
    [HttpPut("increase-prices")]
    public IActionResult IncreasePrices([FromQuery] decimal percentage)
    {
        var products = _productService.GetProducts();
        products.IncreasePrices(percentage);
        return Ok(products);
    }
}
