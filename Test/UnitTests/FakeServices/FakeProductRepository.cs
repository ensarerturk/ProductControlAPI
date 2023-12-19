using DefaultNamespace;
using NewProductManagement.Models;

namespace NewProductManagement.Test.UnitTests.FakeServices;

public class FakeProductRepository : IProductRepository
{
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Product 1", Price = 10.99M, GenreId = 1},
        new Product { Id = 2, Name = "Product 2", Price = 19.99M, GenreId = 2},
    };
    
    public List<Product> GetProducts()
    {
        return _products;
    }

    public Product GetProductById(int id)
    {
        return _products.Find(p => p.Id == id);
    }

    public void CreateProduct(Product newProduct)
    {
        if (newProduct == null)
        {
            throw new ArgumentNullException(nameof(newProduct));
        }

        if (string.IsNullOrWhiteSpace(newProduct.Name) || newProduct.Price < 0)
        {
            throw new ArgumentException("Name and Price are required and should be valid.");
        }

        newProduct.Id = GetProductNextId();
        _products.Add(newProduct);
    }

    public void UpdateProduct(int id, Product updateProduct)
    {
        var existingProduct = _products.Find(p => p.Id == id);

        if (existingProduct != null)
        {
            existingProduct.Name = updateProduct.Name;
            existingProduct.Price = updateProduct.Price;
            existingProduct.GenreId = updateProduct.GenreId;
        }
    }

    public void DeleteProduct(int id)
    {
        var existingProduct = _products.Find(p => p.Id == id);
        if (existingProduct != null)
        {
            _products.Remove(existingProduct);
        }
    }

    public List<Product> GetProductsByName(string name)
    {
        return _products.FindAll(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
    }

    public List<Product> GetProductsByNameAndSort(string name, string sort)
    {
        var filteredProducts = _products.FindAll(p => p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        if (sort.Equals("asc", StringComparison.OrdinalIgnoreCase))
        {
            filteredProducts.Sort((p1, p2) => string.Compare(p1.Name, p2.Name, StringComparison.Ordinal));
        }
        else if (sort.Equals("desc", StringComparison.OrdinalIgnoreCase))
        {
            filteredProducts.Sort((p1, p2) => string.Compare(p2.Name, p1.Name, StringComparison.Ordinal));
        }

        return filteredProducts;
    }

    private int GetProductNextId()
    {
        return _products.Count > 0 ? _products[_products.Count - 1].Id + 1 : 1;
    }
}