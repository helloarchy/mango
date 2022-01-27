using Mango.Services.ProductAPI.Models;

namespace Mango.Services.ProductAPI.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }
    
    public DbSet<Product> Products { get; set; }
}