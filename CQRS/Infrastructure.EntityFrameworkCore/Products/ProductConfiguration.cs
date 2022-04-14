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
        }
    }
}
