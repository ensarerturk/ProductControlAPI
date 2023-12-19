using NewProductManagement.Models;

namespace NewProductManagement.Extensions;

public static class ProductExtensions
{
    // A special extension method for the Product class: formats the product information as a string.
    public static string FormatProductInfo(this Product product)
    {
        return $"ID: {product.Id}, Name: {product.Name}, Price: {product.Price:C}, GenreId: {product.GenreId}";
    }
}