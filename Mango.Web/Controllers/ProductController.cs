﻿using Mango.Web.Models;
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

    public IActionResult CreateProduct()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateProduct(ProductDto model)
    {
        if (ModelState.IsValid)
        {
            var response = await _productService.CreateProductAsync<ResponseDto>(model);

            if (response is not null && response.IsSuccess)
            {
                return RedirectToAction(nameof(ProductIndex));
            }
        }

        return View(model);
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