namespace Facade;

public static class Structural
{
    public static void Execute()
    {
        Facade facade = new Facade();
        facade.MethodA();
        facade.MethodB();
    }
}

public class Facade
{
    SubSystemOne one;
    SubSystemTwo two;
    SubSystemThree three;
    SubSystemFour four;
    public Facade()
    {
        one = new SubSystemOne();
        two = new SubSystemTwo();
        three = new SubSystemThree();
        four = new SubSystemFour();
    }
    public void MethodA()
    {
        Console.WriteLine("\nMethodA() ---- ");
        one.MethodOne();
        two.MethodTwo();
        four.MethodFour();
    }
    public void MethodB()
    {
        Console.WriteLine("\nMethodB() ---- ");
        two.MethodTwo();
        three.MethodThree();
    }
}

class SubSystemOne
{
    public void MethodOne()
    {
        Console.WriteLine($"Called {GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
    }
}

class SubSystemTwo
{
    public void MethodTwo()
    {
        Console.WriteLine($"Called {GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
    }
}
class SubSystemThree
{
    public void MethodThree()
    {
        Console.WriteLine($"Called {GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
    }
}

class SubSystemFour
{
    public void MethodFour()
    {
        Console.WriteLine($"Called {GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
    }
}

