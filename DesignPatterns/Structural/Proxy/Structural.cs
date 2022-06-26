namespace Proxy;

public static class Structural
{
    public static void Execute()
    {
       
        Subject proxy = new Proxy(new RealSubject());
        proxy.Request();
    }
}


abstract class Subject
{
    public abstract void Request();
}

class RealSubject : Subject
{
    public override void Request()
    {
        Console.WriteLine($"Called {GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
    }
}

class Proxy : Subject
{
    private readonly RealSubject realSubject;

    public Proxy(RealSubject realSubject)
    {
        this.realSubject = realSubject;
    }

    public override void Request()
    {
        realSubject.Request();
    }
}
