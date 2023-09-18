
public delegate void SumCallBackDelegate(int currentNumber);
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Thread thread = Thread.CurrentThread;
        thread.Name = "Main Thread";
        Console.WriteLine(thread.Name);

        Thread thread1 = new Thread(Method1)
        {
            Name = "thread1"
        };

        Thread thread2 = new Thread(Method2);


        //Get values from a thread
        SumCallBackDelegate _calback = new SumCallBackDelegate(sumDelegateMethod);
        int maxNumber = 10;


        HelperThread helper = new HelperThread(maxNumber, _calback);
        ThreadStart obj = new ThreadStart(helper.SumNumer);
        Thread thread3 = new Thread(obj)
        {
            Name = "thread3"
        };

        thread1.Start();
        thread2.Start();
        thread3.Start();

       

        Console.WriteLine("Main Thread has ended");

        Console.ReadLine();
    }

    public static void sumDelegateMethod(int sumNumber)
    {
        Console.WriteLine($"The sum is equal to {sumNumber}");
    }

    public static void Method1()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Method1 {i}");
            if(i==2)
                Thread.Sleep(1000);
        }
        Console.WriteLine($"Thread has ended Method1 {Thread.CurrentThread.Name}");
    }
    public static void Method2()
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine($"Method2 {i}");
            if (i == 5)
                Thread.Sleep(1000);
        }
        Console.WriteLine("Thread has ended Method2");
    }

   
}

/// <summary>
/// In order to pass parameters 
/// </summary>
public class HelperThread
{
    private int maxNumber;
    private SumCallBackDelegate cDelegate;

    public HelperThread(int maxNumber, SumCallBackDelegate cDelegate)
    {
        this.maxNumber = maxNumber;
        this.cDelegate = cDelegate;
    }

    public void SumNumer()
    {
        int sum =0;
        for (int i = 0; i < maxNumber; i++)
        {
            sum += 1;

        }
        if(cDelegate != null)
            cDelegate(sum);
        Console.WriteLine($"Thread has ended Method3 {Thread.CurrentThread.Name}");
    }
}