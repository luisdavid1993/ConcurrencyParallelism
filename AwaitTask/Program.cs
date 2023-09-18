internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} in Main started");


        //1)  With void
        Task task = Task.Run(() => { PrintCounter(); });
        task.Wait();


        //2) With parameters
        Task<int> taskParameters = Task.Run(() =>
        {
            return TotalCounter(5);
        });
        taskParameters.Wait();
        int total = taskParameters.Result;
        Console.WriteLine($"Total sum :{total}");


        //3) With complex objects
        Task<Student> taskComplex = Task.Run(() =>
        {
            return GetOne(5);
        });
        taskComplex.Wait();
        Student student= taskComplex.Result;
        Console.WriteLine($"student info => {student}");


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

    static int TotalCounter(int max)
    {
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} in TotalCounter started");
        for (int i = 0; i < max; i++)
        {
            Console.WriteLine($"TotalCounter number {i}");
        }
        Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId} in TotalCounter finish");
        return 10;
    }

    static Student GetOne(int id)
    {
        return new Student() { ID = 10, Name = "Test" };
    }
}
public class Student
{
    public int ID { get; set; }
    public string Name { get; set; }

    public override string ToString()
    {
        return $"{ID} : {Name}";
    }
}