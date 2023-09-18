/// <summary>
/// work syncronous
/// </summary>
internal class Program
{
    static object _lock = new object();
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Thread thread = new Thread(WriteMethod) { Name = "WriteMethodTread" };
        Thread threadRead = new Thread(ReadMethod) { Name = "ReadMethodTread" };

        thread.Start();
        threadRead.Start();

        // the Main tread wait until these two method finish
        thread.Join();
        threadRead.Join();

        Console.ReadLine();


    }

    public static void WriteMethod()
    {
        Monitor.Enter(_lock);
        for (int i = 0; i < 5; i++)
        {
            Monitor.Pulse(_lock);
            Console.WriteLine($"WriteMethod is working .... {i}");
            Console.WriteLine($"WriteMethod is completed .... {i}");
            Monitor.Wait(_lock);
        }
    }
    public static void ReadMethod()
    {
        Monitor.Enter(_lock);
        for (int i = 0; i < 5; i++)
        {
            Monitor.Pulse(_lock);
            Console.WriteLine($"ReadMethod is working .... {i}");
            Console.WriteLine($"ReadMethod is completed .... {i}");
            Monitor.Wait(_lock);
        }
    }
}