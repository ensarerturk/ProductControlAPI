using DefaultNamespace;
using NewProductManagement.Models;
using NewProductManagement.Services;

namespace NewProductManagement.Test.UnitTests.FakeServices;

public class FakeProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public FakeProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
    }

    public List<Product> GetProducts()
    {
        return _productRepository.GetProducts();
    }

    public Product GetProductById(int id)
    {
        return _productRepository.GetProductById(id);
    }

    public void CreateProduct(Product newProduct)
    {
        _productRepository.CreateProduct(newProduct);
    }

    public void UpdateProduct(int id, Product updateProduct)
    {
        _productRepository.UpdateProduct(id, updateProduct);
    }

    public void DeleteProduct(int id)
    {
        _productRepository.DeleteProduct(id);
    }

    public List<Product> GetProductsByName(string name)
    {
        return _productRepository.GetProductsByName(name);
    }

    public List<Product> GetProductsByNameAndSort(string name, string sort)
    {
        return _productRepository.GetProductsByNameAndSort(name, sort);
    }
}