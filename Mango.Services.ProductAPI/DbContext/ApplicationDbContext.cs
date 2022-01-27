namespace Mango.Services.ProductAPI.DbContext;

public class ApplicationDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    
    
}