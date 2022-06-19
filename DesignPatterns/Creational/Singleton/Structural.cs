namespace Singleton;
public static class Structural
{
    public static void Execute()
    {
        Singleton s1 = Singleton.Instance;
        Singleton s2 = Singleton.Instance;

        if (s1 == s2)
            Console.WriteLine("s1 and s2 are the same instance");
        else
            Console.WriteLine("s1 and s2 are different instances");
    }
}

class Singleton
{
    static Singleton instance;
    static readonly object syncRoot = new();

    Singleton() { }

    public static Singleton Instance
    {
        get
        {
            if (instance == null)
                lock (syncRoot)
                    if (instance == null)
                        instance = new Singleton();

            return instance;
        }
    }
}
