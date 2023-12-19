using DefaultNamespace;
using NewProductManagement.Models;

namespace NewProductManagement.Services;

/*
 * The ProductService class implements the IProductService interface and performs product operations
 * through IProductRepository. 
 */
public class ProductService : IProductService
{
    // Instance of IProductRepository for product operations.
    private readonly IProductRepository _productRepository;

    // Constructor of the ProductService class, takes an instance of IProductRepository.
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    // Method to retrieve all products.
    public List<Product> GetProducts()
    {
        return _productRepository.GetProducts();
    }

    // Method to retrieve a product with a specific identifier.
    public Product GetProductById(int id)
    {
        var productById = _productRepository.GetProductById(id);

        if (productById == null)
        {
            throw new Exception($"Product with ID {id} not found.");
        }

        return productById;
    }

    // Method to create a new product.
    public void CreateProduct(Product newProduct)
    {
        _productRepository.CreateProduct(newProduct);
    }

    // Method to update a product with a specific identifier.
    public void UpdateProduct(int id, Product updateProduct)
    {
        var existingProduct = _productRepository.GetProductById(id);

        if (existingProduct == null)
        {
            throw new Exception($"Product with ID {id} not found.");
        }

        _productRepository.UpdateProduct(id, updateProduct);
    }

    // Method to delete a product with a specific identifier.
    public void DeleteProduct(int id)
    {
        var existingProduct = _productRepository.GetProductById(id);

        if (existingProduct == null)
        {
            throw new Exception($"Product with ID {id} not found.");
        }

        _productRepository.DeleteProduct(id);
    }

    // Method to retrieve products with a given name.
    public List<Product> GetProductsByName(string name)
    {
        return _productRepository.GetProductsByName(name);
    }

    // Method to retrieve products by name and sorting criteria.
    public List<Product> GetProductsByNameAndSort(string name, string sort)
    {
        return _productRepository.GetProductsByNameAndSort(name, sort);
    }
}
