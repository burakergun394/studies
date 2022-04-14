using Domain.Products;
using Infrastructure.EntityFrameworkCore.Contexts;
using Infrastructure.EntityFrameworkCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFrameworkCore.Products
{
    public class EfCoreProductRepository : EfCoreRepository<Product, CustomDbContext>, IProductRepository
    {
        public EfCoreProductRepository(CustomDbContext context) : base(context)
        {

        }
    }
}
