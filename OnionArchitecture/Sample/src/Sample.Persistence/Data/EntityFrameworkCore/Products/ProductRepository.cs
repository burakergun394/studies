using Sample.Application.Products.Interfaces.Repositories;
using Sample.Domain.Products;
using Sample.Persistence.Data.EntityFrameworkCore.Common;
using Sample.Persistence.Data.EntityFrameworkCore.Context;

namespace Sample.Persistence.Data.EntityFrameworkCore.Products;

public class ProductRepository : GenericRepository<Product>, IProductRepository
{
    public ProductRepository(ApplicationDbContext context) : base(context)
    {
    }
}
