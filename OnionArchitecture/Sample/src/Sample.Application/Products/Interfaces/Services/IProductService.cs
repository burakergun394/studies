using Sample.Application.Products.Dtos;

namespace Sample.Application.Products.Interfaces.Services;

public interface IProductService
{
    Task<List<ProductDto>> GetAllAsync();
}
