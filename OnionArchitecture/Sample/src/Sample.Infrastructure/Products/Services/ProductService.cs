using Sample.Application.Products.Dtos;
using Sample.Application.Products.Interfaces.Repositories;
using Sample.Application.Products.Interfaces.Services;

namespace Sample.Infrastructure.Products.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository productRepository;

    public ProductService(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

    public async Task<List<ProductDto>> GetAllAsync()
    {
        var datas = await productRepository.GetAllAsync();

        var result = new List<ProductDto>();

        datas.ForEach(x => result.Add(new ProductDto
        {
            Id = x.Id,
            Name = x.Name,
        }));

        return result;
    }
}
