


using System.Threading;
/// <summary>
/// Is a Synchronization primitive that grants exclusive access to the shared resource to only on thread.
/// If a Thread acquires a Mutex, the second thread that wants to acquire that Mutex
/// is suspended until the first thread release the Mutex.
/// </summary>


internal class Program
{
    static Mutex _mutex = new Mutex();
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        for (int i = 0; i < 5; i++)
        {
            Thread thread = new Thread(Write);
            thread.Name = $"Thread {i}";
            thread.Start();
        }


        //to test mutex
        // we are tryign to release Mutex form child class, but in this contex we don not have _mutex.WaitOne()
        //This Throw an exeption

        //Thread.Sleep(4000);
        //_mutex.ReleaseMutex(); 

        Console.ReadLine();
    }
    public static void Write()
    {
        Console.WriteLine($"Writen waiting {Thread.CurrentThread.Name}");
        _mutex.WaitOne();
        Console.WriteLine($"Writen started {Thread.CurrentThread.Name}");

        Thread.Sleep(5000);// testing 
        Console.WriteLine($"Writen finish ------------------------ {Thread.CurrentThread.Name}");
        _mutex.ReleaseMutex();

    }
}