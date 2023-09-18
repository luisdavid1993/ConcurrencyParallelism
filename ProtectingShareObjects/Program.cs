using System.Numerics;


internal class Program
{
    public static int Sum = 0;
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Thread t1 = new Thread(Addition) { Name = "Tread 1" };
        Thread t2 = new Thread(Addition) { Name = "Tread 2" };
        Thread t3 = new Thread(Addition) { Name = "Tread 3" };

        t1.Start();
        t2.Start();
        t3.Start();

        // attach t1 to Main Thread
        // because we want to wait until these thread finish and get the Sum at the and
        t1.Join();
        t2.Join();
        t3.Join();

        Console.WriteLine($"Total sum is {Sum}");

        Console.ReadLine();
    }

    // this can be used to protected from the multi threads runnigs
    public static object _lock = new object();
    public static void Addition()
    {
        for (int i = 0; i < 5000; i++)
        {
            //Sum++;

            // 2) Interlocked.Increment protected sum variable to the multi threads runnings Interlocked.Increment(ref Sum)
            // Interlocked.Increment(ref Sum);

            // 1) this can be used to protected from the multi threads runnigs
            //lock (_lock)
            //{ 
            // Sum++;
            //}

            //3) Using Monitor
            bool monitorIsWorking = false; // this code is optional
            Monitor.Enter(_lock, ref monitorIsWorking);
            try
            {
              Sum++;
            }
            finally
            {
                if(monitorIsWorking)
                    Monitor.Exit(_lock);
            }
        }
    }
}