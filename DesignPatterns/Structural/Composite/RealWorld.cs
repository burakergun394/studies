namespace Composite;

public static class RealWorld
{
    public static void Execute()
    {
        CompositeElement root = new CompositeElement("Picture");
        root.Add(new PrimitiveElement("Red Line"));
        root.Add(new PrimitiveElement("Blue Circle"));
        root.Add(new PrimitiveElement("Green Box"));

        CompositeElement comp = new CompositeElement("Two Circles");
        comp.Add(new PrimitiveElement("Black Circle"));
        comp.Add(new PrimitiveElement("White Circle"));
        root.Add(comp);

        PrimitiveElement pe = new PrimitiveElement("Yellow Line");
        root.Add(pe);
        root.Remove(pe);
        root.Display(1);
    }
}

abstract class DrawingElement
{
    protected string name;
    public DrawingElement(string name)
    {
        this.name = name;
    }
    public abstract void Add(DrawingElement d);
    public abstract void Remove(DrawingElement d);
    public abstract void Display(int indent);
}

class PrimitiveElement : DrawingElement
{
    public PrimitiveElement(string name)
        : base(name)
    {
    }
    public override void Add(DrawingElement c)
    {
        Console.WriteLine(
            "Cannot add to a PrimitiveElement");
    }
    public override void Remove(DrawingElement c)
    {
        Console.WriteLine(
            "Cannot remove from a PrimitiveElement");
    }
    public override void Display(int indent)
    {
        Console.WriteLine("-" + indent.ToString() + "-" + name);
    }
}

class CompositeElement : DrawingElement
{
    List<DrawingElement> elements = new List<DrawingElement>();
    public CompositeElement(string name)
        : base(name)
    {
    }
    public override void Add(DrawingElement d)
    {
        elements.Add(d);
    }
    public override void Remove(DrawingElement d)
    {
        elements.Remove(d);
    }
    public override void Display(int indent)
    {
        Console.WriteLine("-" + indent.ToString() + "-" + name);

        foreach (DrawingElement d in elements)
        {
            d.Display(indent + 2);
        }
    }
}

