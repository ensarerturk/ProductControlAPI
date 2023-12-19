using Microsoft.AspNetCore.Mvc;
using NewProductManagement.Extensions;
using NewProductManagement.Models;
using NewProductManagement.Services;

namespace NewProductManagement.Controllers;

[ApiController]
[Route("api/v1/product-managements")]
public class ProductManagementController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductManagementController(IProductService productService)
    {
        _productService = productService;
    }
    
    // GET endpoint to retrieve all products.
    [HttpGet]
    public IActionResult GetAll()
    {
        var products = _productService.GetProducts();
        return Ok(products);
    }

    // GET endpoint to retrieve a product by its unique identifier.
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        try
        {
            var productById = _productService.GetProductById(id);
            return Ok(productById.FormatProductInfo());
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // POST endpoint to create a new product.
    [HttpPost]
    public IActionResult Create([FromBody] Product newProduct)
    {
        try
        {
            _productService.CreateProduct(newProduct);
            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id }, newProduct);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    // PUT endpoint to update an existing product.
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Product updatedProduct)
    {
        try
        {
            _productService.UpdateProduct(id, updatedProduct);
            return Ok();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    // DELETE endpoint to delete a product by its unique identifier.
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _productService.DeleteProduct(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }
}