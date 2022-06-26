namespace Bridge;
public static class Structural
{
    public static void Execute()
    {
        Abstraction abstraction = new Abstraction(new ConcreteImplementorA());
        Abstraction abstraction2 = new RefinedAbstraction(new ConcreteImplementorB());

        abstraction.Operation();
        abstraction2.Operation();
    }
}

interface Implementor
{
    void OperationImp();
}

class ConcreteImplementorA : Implementor
{
    public void OperationImp() =>
        Console.WriteLine($"Called {GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
}

class ConcreteImplementorB : Implementor
{
    public void OperationImp() =>
        Console.WriteLine($"Called {GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
}

class Abstraction
{
    protected readonly Implementor implementor;

    public Abstraction(Implementor implementor)
    {
        this.implementor = implementor;
    }

    public virtual void Operation() => implementor.OperationImp();
}

class RefinedAbstraction : Abstraction
{
    public RefinedAbstraction(Implementor implementor) : base(implementor)
    {
    }

    public override void Operation() => implementor.OperationImp();
}
