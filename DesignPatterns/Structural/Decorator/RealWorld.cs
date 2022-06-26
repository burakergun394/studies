namespace Decorator;

public static class RealWorld
{
    public static void Execute()
    {
        Book book = new Book("Worley", "Inside ASP.NET", 10);
        book.Display();

        Video video = new Video("Spielberg", "Jaws", 23, 92);
        video.Display();

        Console.WriteLine("\nMaking video borrowable:");

        Borrowable borrowvideo = new Borrowable(video);
        borrowvideo.BorrowItem("Customer #1");
        borrowvideo.BorrowItem("Customer #2");
        borrowvideo.Display();
    }
}

abstract class LibraryItem
{
    public int NumCopies { get; set; }
   
    public abstract void Display();
}

class Book : LibraryItem
{
    private string author;
    private string title;

    public Book(string author, string title, int numCopies)
    {
        this.author = author;
        this.title = title;
        this.NumCopies = numCopies;
    }
    public override void Display()
    {
        Console.WriteLine("\nBook ------ ");
        Console.WriteLine(" Author: {0}", author);
        Console.WriteLine(" Title: {0}", title);
        Console.WriteLine(" # Copies: {0}", NumCopies);
    }
}

class Video : LibraryItem
{
    private string director;
    private string title;
    private int playTime;

    public Video(string director, string title, int numCopies, int playTime)
    {
        this.director = director;
        this.title = title;
        this.NumCopies = numCopies;
        this.playTime = playTime;
    }
    public override void Display()
    {
        Console.WriteLine("\nVideo ----- ");
        Console.WriteLine(" Director: {0}", director);
        Console.WriteLine(" Title: {0}", title);
        Console.WriteLine(" # Copies: {0}", NumCopies);
        Console.WriteLine(" Playtime: {0}\n", playTime);
    }
}

abstract class DecoratorClass2 : LibraryItem
{
    protected LibraryItem libraryItem;
    public DecoratorClass2(LibraryItem libraryItem)
    {
        this.libraryItem = libraryItem;
    }
    public override void Display()
    {
        libraryItem.Display();
    }
}

class Borrowable : DecoratorClass2
{
    protected readonly List<string> borrowers = new List<string>();
    public Borrowable(LibraryItem libraryItem)
        : base(libraryItem)
    {
    }
    public void BorrowItem(string name)
    {
        borrowers.Add(name);
        libraryItem.NumCopies--;
    }
    public void ReturnItem(string name)
    {
        borrowers.Remove(name);
        libraryItem.NumCopies++;
    }
    public override void Display()
    {
        base.Display();
        foreach (string borrower in borrowers)
        {
            Console.WriteLine(" borrower: " + borrower);
        }
    }
}