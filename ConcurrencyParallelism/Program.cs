using System.Net.Http.Headers;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine($"Hello, World! , Thread = {Thread.CurrentThread.ManagedThreadId}");

        TestTheads testTheads = new TestTheads();

        Task.Factory.StartNew(() => 
        { 
            testTheads.TestTask(1);
            testTheads.TestTask2(1);
            
        });



        Task<Dictionary<string, string>> taskDictionary = Task.Run(() => testTheads.TestTaskDictionary(5));
        taskDictionary.Wait();
        Dictionary<string, string> dicList = taskDictionary.Result;
        foreach (var item in dicList)
        {
            Console.WriteLine(item.Value);
        }

        Console.WriteLine("Main thead Completed");

        Console.ReadKey();
    }

   
}

public class TestTheads
{


    public  string TestTask(int leng)
    {
        Console.WriteLine($"Inicia TestTask = {leng}, Thread = {Thread.CurrentThread.ManagedThreadId}");
        return $"Inicia TestTask = {leng}, Thread = {Thread.CurrentThread.ManagedThreadId}";
    }

    public int TestTask2(int leng)
    {
        Console.WriteLine($"Inicia TestTask 2, Thread = {Thread.CurrentThread.ManagedThreadId}");
        return leng;
    }

    public Dictionary<string, string> TestTaskDictionary(int leng)
    {
        Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
        Console.WriteLine($"Inicia TestTaskDictionary, Thread = {Thread.CurrentThread.ManagedThreadId}");
        keyValuePairs.Add("1", "aaaa");
        keyValuePairs.Add("2", "bbbbb");
        keyValuePairs.Add("3", "ccccc");
        keyValuePairs.Add("4", "ddddd");
        keyValuePairs.Add("5", "eeeeee");
        return keyValuePairs;
    }
}

