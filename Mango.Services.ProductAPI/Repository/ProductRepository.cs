using AutoMapper;
using Mango.Services.ProductAPI.DbContext;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    private readonly IMapper _mapper;

    public ProductRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ProductDto>> GetProducts()
    {
        var products = await _db.Products.ToListAsync();
        return _mapper.Map<List<ProductDto>>(products);
    }

    public async Task<ProductDto> GetProductById(int productId)
    {
        var product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteProduct(int productId)
    {
        try
        {
            var product = await _db.Products.FirstOrDefaultAsync(p => p.ProductId == productId);
            if (product is null)
            {
                return false;
            }
            
            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}