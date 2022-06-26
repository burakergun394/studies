namespace Bridge;
public static class RealWorld
{
    public static void Execute()
    {
        var customers = new Customers();
        customers.DataObject = new CustomersData("Istanbul");

        customers.Show();
        customers.Next();
        customers.Show();
        customers.Next();
        customers.Show();
        customers.Add("Feyza Ergün");

        customers.ShowAll();
    }

    class CustomersBase
    {
        public DataObject DataObject { get; set; }

        public virtual void Next() =>
            DataObject.NextRecord();

        public virtual void Prior() =>
            DataObject.PriorRecord();

        public virtual void Add(string customer) => 
            DataObject.AddRecord(customer);
        
        public virtual void Remove(string customer) =>
            DataObject.DeleteRecord(customer);

        public virtual void Show() => 
            DataObject.ShowRecord();

        public virtual void ShowAll() => 
            DataObject.ShowAllRecords();
    }

    class Customers: CustomersBase
    {
        public override void ShowAll()
        {
            Console.WriteLine("----------");
            base.ShowAll();
            Console.WriteLine("----------");
        }
    }

    abstract class DataObject
    {
        public abstract void NextRecord();
        public abstract void PriorRecord();
        public abstract void AddRecord(string name);
        public abstract void DeleteRecord(string name);
        public abstract string GetCurrentRecord(string name);
        public abstract void ShowRecord();
        public abstract void ShowAllRecords();
    }

    class CustomersData : DataObject
    {
        private readonly List<string> customers;
        private int current;
        private string city;

        public CustomersData(string city)
        {
            customers = new List<string>();
            current = 0;
            this.city = city;

            customers.Add("Burak Ergün");
            customers.Add("Emre Düver");
            customers.Add("Emre Alkan");
            customers.Add("Emre Özel");
            customers.Add("Emre İnç");
        }

        public override void AddRecord(string name)
        {
            customers.Add(name);
        }

        public override void DeleteRecord(string name)
        {
            customers.Remove(name);
        }

        public override string GetCurrentRecord(string name)
        {
            return customers[current];
        }

        public override void NextRecord()
        {
            if (current <= customers.Count - 1) current++;
        }

        public override void PriorRecord()
        {
            if (current > 0) current--;
        }

        public override void ShowAllRecords()
        {
            Console.WriteLine("Customer City: " + city);

            customers.ForEach(x =>
            {
                Console.WriteLine($"{x}");
            });
        }

        public override void ShowRecord()
        {
            Console.WriteLine(customers[current]);
        }
    }
}