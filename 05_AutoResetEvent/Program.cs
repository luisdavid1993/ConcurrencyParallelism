/// <summary>
/// Is used for sending signals between two threads. Both Thread share the same autoResetEventObject. 
/// Work in order inside the threads. When one thread is complete another 
/// 
/// Mutex is better than AutoResetEvent
/// </summary>
internal class Program
{
    static AutoResetEvent _event = new AutoResetEvent(true);
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        for (int i = 0; i < 5; i++)
        {
            Thread thread = new Thread(Write);
            thread.Name = $"Thread {i}";
            thread.Start();
        }

        Console.ReadLine();
    }

    public static void Write()
    {
        Console.WriteLine($"Writen waiting {Thread.CurrentThread.Name}");
        _event.WaitOne();
        Console.WriteLine($"Writen started {Thread.CurrentThread.Name}");

        Thread.Sleep(5000);// testing 
        Console.WriteLine($"Writen finish ------------------------ {Thread.CurrentThread.Name}");
        _event.Set();
        
    }
}

