internal class Program
{
    private static  void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} in Main started");

        //1) Normal way
        Task task = new Task(PrintCounter);
        task.Start();

        //2) With factory key word
        Task.Factory.StartNew(() => PrintCounter());

        //3) Run way
        Task taskRun = Task.Run(() => { PrintCounter(); ReturnCounter(); });

        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} in Main completed");

        Console.ReadLine();
    }
    static void PrintCounter()
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} in PrintCounter started");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"number {i}");
        }
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} in PrintCounter finish");
    }

    static int ReturnCounter()
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} in ReturnCounter started");
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine($"number {i}");
        }
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} in ReturnCounter finish");
        return 5;
    }
}