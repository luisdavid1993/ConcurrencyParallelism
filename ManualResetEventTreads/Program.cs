
/// <summary>
/// Wait until one tread write o get something to read or get something. Is set order in treads.
/// </summary>
internal class Program
{
    // Start in false (mining block the thread)
    static ManualResetEvent _resetEvent = new ManualResetEvent(false);
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Thread thread = new Thread(Write);
        thread.Start();

        for (int i = 0; i < 5; i++)
        {
            new Thread(Read).Start();
        }
        

        Console.ReadLine(); 
    }
    private static void Write()
    {

        Console.WriteLine("Writen started");

        _resetEvent.Reset(); // block all treads
        Thread.Sleep(5000);// testing 
        Console.WriteLine("Writen finish ------------------------");

        _resetEvent.Set(); // release treads
    }

    private static void Read()
    {
        Console.WriteLine("Read started");
        _resetEvent.WaitOne(); // wait its turn of run  _resetEvent.Set() allow it to START
        Console.WriteLine("Read finish");
    }
}