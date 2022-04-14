using Core.Helpers;
using Domain.AggregateRoots;
using Domain.Entities;
using Domain.Shared.Products;

namespace Domain.Products
{
    public class Product: BaseAggregateRoot, IEntity
    {
        public string Code { get; protected set; }
        public string Name { get; protected set; }

        protected Product() { }

        public Product(string code, string name)
        {
            SetCode(code);
            SetName(name);
        }

        public void SetCode(string code)
        {
            Check.NotNullOrWhiteSpace(code, nameof(Code), ProductConsts.MaxCodeLength);
            Code = code;
        }
        public void SetName(string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(Name), ProductConsts.MaxNameLength);
            Name = name;
        }
    }
}
