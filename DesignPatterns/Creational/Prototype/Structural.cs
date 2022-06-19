namespace Prototype
{
    public static class Structural
    {
        public static void Execute()
        {
            ConcretePrototype1 p1 = new("I", new Product { Name = "P-1"});
            ConcretePrototype1 c1 = (ConcretePrototype1)p1.Clone();
            c1.Product.Name = "P-11";

            ConcretePrototype2 p2 = new("II", new Product { Name = "P-2" });
            ConcretePrototype2 c2 = (ConcretePrototype2)p2.Clone();

            Console.WriteLine("Cloned p1 to c1 : {0}, {1}, {2}, {3}", p1.Id, p1.Product.Name, c1.Id, c1.Product.Name);
            Console.WriteLine("Cloned p2 to c2 : {0}, {1}, {2}, {3}", p2.Id, p2.Product.Name, c2.Id, c2.Product.Name);
        }
    }
    class Product
    {
        public string Name { get; set; }
    }

    abstract class Prototype
    {
        public string Id { get; }
        public Product Product { get; }
        public Prototype(string id, Product product)
        {
            Id = id;
            Product = product;
        }

        public abstract Prototype Clone();
    }

    class ConcretePrototype1 : Prototype
    {
        public ConcretePrototype1(string id, Product product) : base(id, product)
        {
        }

        /// <summary>
        /// Return a shallow copy
        /// </summary>
        /// <returns></returns>
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }

    class ConcretePrototype2 : Prototype
    {
        public ConcretePrototype2(string id, Product product) : base(id, product)
        {
        }

        /// <summary>
        /// Return a shallow copy
        /// </summary>
        /// <returns></returns>
        public override Prototype Clone()
        {
            return (Prototype)this.MemberwiseClone();
        }
    }
}
