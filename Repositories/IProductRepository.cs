using NewProductManagement.Models;

namespace DefaultNamespace;

// The IProductRepository interface defines methods for product database operations.
public interface IProductRepository
{
    // Method to retrieve all products.
    List<Product> GetProducts();
    
    // Method to retrieve a product with a specific identifier.
    Product GetProductById(int id);
    
    // Method to create a new product.
    void CreateProduct(Product newProduct);
    
    // Method to update a product with a specific identifier.
    void UpdateProduct(int id, Product updateProduct);
    
    // Method to delete a product with a specific identifier.
    void DeleteProduct(int id);
    
    // Method to retrieve products with a given name.
    List<Product> GetProductsByName(string name);
    
    // Method to retrieve products by name and sorting criteria.
    List<Product> GetProductsByNameAndSort(string name, string sort);
}