internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Main started");
        for (int i = 0; i < 5; i++)
        {
            ThreadPool.QueueUserWorkItem(x=> ThreadPoolMethod("aaa"));
        }
        Console.WriteLine("Main completed");

        Console.ReadLine();
    }

    public static void ThreadPoolMethod(object obj)
    { 
     Thread thread= Thread.CurrentThread;
        string message = $"Background: {thread.IsBackground}, thread pool: {thread.IsThreadPoolThread}, thread id: {thread.ManagedThreadId} ";
        Console.WriteLine(message);
    }
}