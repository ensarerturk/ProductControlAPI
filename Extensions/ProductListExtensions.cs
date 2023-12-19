using NewProductManagement.Models;

namespace NewProductManagement.Extensions;

public static class ProductListExtensions
{
    // A special extension method for the List<Product> type: Filters products with a specific genreId.
    public static List<Product> FilterByGenre(this List<Product> products, int genreId)
    {
        return products.Where(p => p.GenreId == genreId).ToList();
    }

    // A special extension method for the List<Product> type: Increases product prices by a certain percentage.
    public static void IncreasePrices(this List<Product> products, decimal percentage)
    {
        foreach (var product in products)
        {
            product.Price += product.Price * (percentage / 100);
        }
    }
}