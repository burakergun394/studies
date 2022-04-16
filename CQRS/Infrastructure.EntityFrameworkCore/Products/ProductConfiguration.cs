using Domain.Products;
using Domain.Shared.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityFrameworkCore.Products
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Code);
            builder.Property(x => x.Code).HasMaxLength(ProductConsts.MaxCodeLength);
            builder.Property(x => x.Code).IsRequired();

            builder.Property(x => x.Name);
            builder.Property(x => x.Name).HasMaxLength(ProductConsts.MaxNameLength);
            builder.Property(x => x.Name).IsRequired();

            builder.Property(x => x.CreatedTime);

            builder.Property(x => x.UpdatedTime);

            var products = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                var product = new Product(
                    $"P-{i + 1}",
                    $"Product-{i + 1}");
                product.Id = i + 1;
                products.Add(product);
                
            }

            builder.HasData(products);
        }
    }
}
