namespace FactoryMethod
{
    public static class Structural
    {
        public static void Execute()
        {
            List<Creator> creators = new();
            creators.Add(new ConcreteCreatorA());
            creators.Add(new ConcreteCreatorB());

            foreach (var creator in creators)
            {
                Product product = creator.FactoryMethod();
                Console.WriteLine("Created {0}", product.GetType().Name);
            }
        }

        abstract class Product
        {

        }

        class ConcreteProductA : Product
        {

        }

        class ConcreteProductB : Product
        {

        }

        abstract class Creator
        {
            public abstract Product FactoryMethod();
        }

        class ConcreteCreatorA : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductA();
            }
        }

        class ConcreteCreatorB : Creator
        {
            public override Product FactoryMethod()
            {
                return new ConcreteProductB();
            }
        }
    }
}
