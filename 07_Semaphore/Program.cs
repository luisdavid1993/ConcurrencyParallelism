using System.Threading;
/// <summary>
/// Is used to limit the number of threads that can have access to a share resource concurrently. 
/// Allows one or more threads to enter into the critical section and execute the task concurrently with thread safety.
/// </summary>
internal class Program
{
    static Semaphore _semaphore = new Semaphore(2, 2);
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
        _semaphore.WaitOne();
        Console.WriteLine($"Writen started --- {Thread.CurrentThread.Name}");

        Thread.Sleep(5000);// testing 
        Console.WriteLine($"Writen finish ------------------------ {Thread.CurrentThread.Name}");
        _semaphore.Release();

    }
}