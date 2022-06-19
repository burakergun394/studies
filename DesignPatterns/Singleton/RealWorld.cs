namespace Singleton;
public static class RealWorld
{
    public static void Execute()
    {
        LoadBalancer lb1 = LoadBalancer.Instance;
        LoadBalancer lb2 = LoadBalancer.Instance;
        LoadBalancer lb3 = LoadBalancer.Instance;
        LoadBalancer lb4 = LoadBalancer.Instance;

        if (lb1 == lb2 && lb2 == lb3 && lb3 == lb4)
            Console.WriteLine("All instance are the same");

        LoadBalancer balancer = LoadBalancer.Instance;
        for (int i = 0; i < 15; i++)
        {
            string server = balancer.Server;
            Console.WriteLine("Dispatch Request to: " + server);
        }
    }
}

class LoadBalancer
{
    static LoadBalancer instance;
    static readonly object syncRoot = new();
    readonly List<string> servers = new();
    readonly Random random = new();
    
    LoadBalancer() 
    {
        servers.Add("ServerI");
        servers.Add("ServerII");
        servers.Add("ServerIII");
        servers.Add("ServerIV");
        servers.Add("ServerV");
    }

    public static LoadBalancer Instance
    {
        get
        {
            if (instance == null)
                lock (syncRoot)
                    if (instance == null)
                        instance = new();
            
            return instance;
        }
    }

    public string Server 
    {
        get
        {
            int r = random.Next(servers.Count);
            return servers[r].ToString();
        } 
    }
}