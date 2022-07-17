using Sample.Domain.Common;

namespace Sample.Domain.Products
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
