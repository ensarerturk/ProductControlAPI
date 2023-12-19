namespace NewProductManagement.Models;

// Product class represents the basic data model for a product.
public class Product
{
    // Private fields representing the identifier of the product.
    private int _id;
    private string _name;
    private decimal _price;
    private int _genreId;

    // Constructor of the Product class that initializes the product properties.
    public Product(int id, string name, decimal price)
    {
        _id = id;
        _name = name;
        _price = price;
    }

    public Product()
    {
    }

    public int GenreId
    {
        get => _genreId;
        set => _genreId = value;
    }

    // A property providing access to the identifier of the product.
    public int Id
    {
        get => _id;
        set => _id = value;
    }

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public decimal Price
    {
        get => _price;
        set => _price = value;
    }
}