using Mango.Web.Models;
using Mango.Web.Services.IServices;

namespace Mango.Web.Services;

public class ProductService : BaseService, IProductService
{
    public ProductService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
    }

    public async Task<T?> GetAllProductsAsync<T>()
    {
        return await SendAsync<T>(new ApiRequest
        {
            ApiType = Sd.ApiType.Get,
            Url = $"{Sd.ProductApiBase}/api/products",
            AccessToken = ""
        });
    }

    public async Task<T?> GetProductByIdAsync<T>(int id)
    {
        return await SendAsync<T>(new ApiRequest
        {
            ApiType = Sd.ApiType.Get,
            Url = $"{Sd.ProductApiBase}/api/products/{id}",
            AccessToken = ""
        });
    }

    public async Task<T?> CreateProductAsync<T>(ProductDto productDto)
    {
        return await SendAsync<T>(new ApiRequest
        {
            ApiType = Sd.ApiType.Post,
            Data = productDto,
            Url = $"{Sd.ProductApiBase}/api/products",
            AccessToken = ""
        });
    }

    public async Task<T?> UpdateProductAsync<T>(ProductDto productDto)
    {
        return await SendAsync<T>(new ApiRequest
        {
            ApiType = Sd.ApiType.Put,
            Url = $"{Sd.ProductApiBase}/api/products",
            AccessToken = ""
        });
    }

    public async Task<T?> DeleteProductAsync<T>(int id)
    {
        return await SendAsync<T>(new ApiRequest
        {
            ApiType = Sd.ApiType.Delete,
            Url = $"{Sd.ProductApiBase}/api/products/{id}",
            AccessToken = ""
        });
    }
}