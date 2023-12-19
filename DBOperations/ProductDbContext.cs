using Microsoft.EntityFrameworkCore;
using NewProductManagement.Models;

namespace NewProductManagement.DBOperations;

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
}