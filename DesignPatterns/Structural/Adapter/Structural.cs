namespace Adapter
{
    public static class Structural
    {
        public static void Execute()
        {
            IAdapter adapter1 = new Adapter1();
            IAdapter adapter2 = new Adapter2();

            adapter1.Request();
            adapter2.Request();
        }
    }

    interface IAdapter
    {
        void Request();
    }

    class Adapter1 : IAdapter
    {
        public void Request()
        {
            Console.WriteLine($"Called {System.Reflection.MethodBase.GetCurrentMethod().Name}");
        }
    }

    class Adapter2 : IAdapter
    {
        private readonly Adaptee adaptee;

        public Adapter2()
        {
            adaptee = new Adaptee();
        }

        public void Request()
        {
            adaptee.SpesificRequest();
        }
    }

    class Adaptee
    {
        public void SpesificRequest()
        {
            Console.WriteLine($"Called {System.Reflection.MethodBase.GetCurrentMethod().Name}");
        }
    }
}

