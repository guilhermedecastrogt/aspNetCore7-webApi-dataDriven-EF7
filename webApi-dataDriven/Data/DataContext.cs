using Microsoft.EntityFrameworkCore;
using webApi_dataDriven.Models;

namespace webApi_dataDriven.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }
    
    public DbSet<ProductModel> Products { get; set; }
    public DbSet<CategoryModel> Categories { get; set; }
    public DbSet<UserModel> Users { get; set; }
}