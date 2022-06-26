namespace Decorator;

public static class Structural
{
    public static void Execute()
    {
        ConcreteComponent c = new ConcreteComponent();
        ConcreteDecoratorA d1 = new ConcreteDecoratorA();
        ConcreteDecoratorB d2 = new ConcreteDecoratorB();

        d1.SetComponent(c);
        d2.SetComponent(d1);

        d2.Operation();
        d1.Operation();
    }
}

abstract class Component
{
    public abstract void Operation();
}

class ConcreteComponent : Component
{
    public override void Operation()
    {
        Console.WriteLine($"Called {GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
    }
}

class DecoratorClass1 : Component
{
    private Component component;

    public void SetComponent(Component component) => this.component = component;

    public override void Operation()
    {
        component.Operation();
    }
}

class ConcreteDecoratorA : DecoratorClass1
{
    public override void Operation()
    {
        base.Operation();
        Console.WriteLine($"Called {GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
    }
}


class ConcreteDecoratorB : DecoratorClass1
{

    public override void Operation()
    {
        base.Operation();
        AddedBehavior();
        Console.WriteLine($"Called {GetType().Name}.{System.Reflection.MethodBase.GetCurrentMethod().Name}");
    }

    void AddedBehavior()
    {

    }
}


