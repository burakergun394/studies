namespace Builder
{
    public static class Structural
    {
        public static void Execute()
        {
            Director director = new();
            Builder builder1 = new ConcreteBuilder1();
            Builder builder2 = new ConcreteBuilder2();

            director.Construct(builder1);
            Product product1 = builder1.GetResult();
            product1.Show();

            director.Construct(builder2);
            Product product2 = builder2.GetResult();
            product2.Show();
        }
    }

    public class Director
    {
        public void Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();
        }
    }

    public abstract class Builder
    {
        public abstract void BuildPartA();
        public abstract void BuildPartB();
        public abstract Product GetResult();

    }

    public class ConcreteBuilder1 : Builder
    {
        private readonly Product _product = new();
        public override void BuildPartA()
        {
            _product.Add("PartA");
        }
        public override void BuildPartB()
        {
            _product.Add("PartB");
        }
        public override Product GetResult()
        {
            return _product;
        }
    }

    public class ConcreteBuilder2 : Builder
    {
        private readonly Product _product = new();
        public override void BuildPartA()
        {
            _product.Add("PartX");
        }
        public override void BuildPartB()
        {
            _product.Add("PartY");
        }
        public override Product GetResult()
        {
            return _product;
        }
    }

    public class Product
    {
        private List<string> _parts = new();
        public void Add(string part) => _parts.Add(part);
        public void Show()
        {
            Console.WriteLine("\nProduct Parts");
            foreach (string part in _parts)
                Console.WriteLine(part);
        }
    }
}
