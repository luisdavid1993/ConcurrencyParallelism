using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine($"Main : {Thread.CurrentThread.ManagedThreadId}");
        int length = 10;
        //01) Parallel for
        Parallel.For(0, length, new ParallelOptions() { MaxDegreeOfParallelism = 3 },
        position =>
        {
            Console.WriteLine($"Parallel  For Position =  {position}  Thread Id = {Thread.CurrentThread.ManagedThreadId}");
        });



        List<int> list = new List<int>();
        list.Add(1);list.Add(2);list.Add(3);list.Add(4);list.Add(5);list.Add(6);
        //02) Parallel ForEach
        Parallel.ForEach(list, new ParallelOptions() { MaxDegreeOfParallelism = 3 }, current =>
        {
            Console.WriteLine($"Parallel  For Position =  {current}  Thread Id = {Thread.CurrentThread.ManagedThreadId}");
        });


        //03) Parallel Invoke
        ParallelOptions options = new ParallelOptions() { MaxDegreeOfParallelism = 1};
        Parallel.Invoke
            (options,
                () => PrintNumber(1),
                () => PrintNumber(5),
                () =>
                {
                   Console.WriteLine($"Parallel  Link maner , Thread Id = {Thread.CurrentThread.ManagedThreadId}");
                }
            );

        Console.WriteLine("Task Completed");
        Console.ReadLine();
    }

    public static void PrintNumber(int number)
    {
        Console.WriteLine($"Parallel  Invoke =  {number}  Thread Id = {Thread.CurrentThread.ManagedThreadId}");
    }
}