using Mango.Web.Models;
using Mango.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Mango.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<ViewResult> ProductIndex()
    {
        var list = new List<ProductDto>();
        var response = await _productService.GetAllProductsAsync<ResponseDto>();

        if (response is not null && response.IsSuccess)
        {
            var result = Convert.ToString(response.Result);
            list = JsonConvert.DeserializeObject<List<ProductDto>>(result);
        }
        
        return View(list);
    }

    public IActionResult Create()
    {
        throw new NotImplementedException();
    }

    public IActionResult EditProduct()
    {
        throw new NotImplementedException();
    }

    public IActionResult DeleteProduct()
    {
        throw new NotImplementedException();
    }
}