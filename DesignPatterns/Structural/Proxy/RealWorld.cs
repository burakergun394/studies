namespace Proxy;

public static class RealWorld
{
    public static void Execute()
    {
        MathProxy proxy = new MathProxy(new Math());

        Console.WriteLine("4 + 2 = " + proxy.Add(4, 2));
        Console.WriteLine("4 - 2 = " + proxy.Sub(4, 2));
        Console.WriteLine("4 * 2 = " + proxy.Mul(4, 2));
        Console.WriteLine("4 / 2 = " + proxy.Div(4, 2));
    }
}

interface IMath
{
    double Add(double x, double y);
    double Sub(double x, double y);
    double Mul(double x, double y);
    double Div(double x, double y);
}

class Math : IMath
{
    public double Add(double x, double y) => x + y;
    public double Sub(double x, double y) => x - y; 
    public double Mul(double x, double y) =>  x * y; 
    public double Div(double x, double y) => x / y;
}

class MathProxy : IMath
{
    private readonly Math math;
    public MathProxy(Math math)
    {
        this.math = math;
    }

    public double Add(double x, double y)
    {
        return math.Add(x, y);
    }
    public double Sub(double x, double y)
    {
        return math.Sub(x, y);
    }
    public double Mul(double x, double y)
    {
        return math.Mul(x, y);
    }
    public double Div(double x, double y)
    {
        return math.Div(x, y);
    }
}