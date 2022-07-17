using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.Application.Products.Dtos;
using Sample.Application.Products.Interfaces.Repositories;
using Sample.Application.Products.Interfaces.Services;

namespace Sample.Presentation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService productService;

    public ProductsController(IProductService productService)
    {
        this.productService = productService;
    }

    [HttpGet]
    [Route("get-all-async")]
    public async Task<IActionResult> GetAllAsync()
    {
        var result = await productService.GetAllAsync();

        return Ok(result);
    }
}
