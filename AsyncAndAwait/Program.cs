using System.Collections.Generic;
using System.Linq.Expressions;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine($"Main : {Thread.CurrentThread.ManagedThreadId}");
        TestAsyncAndAwait test = new TestAsyncAndAwait();
        string result =  test.Print().Result;// attaching this thread to Main thread
        Console.WriteLine(result);
        Console.WriteLine("Task Completed");
    }
}
public class TestAsyncAndAwait
{
    public async Task<string> Print()
    {
        Student student = await GetOne(10);
        Console.WriteLine($"Thread : {Thread.CurrentThread.ManagedThreadId}");
        return student.ToString();
    }
    public async Task<Student> GetOne(int ID)
    {
        List<Student> students = await GetList();
        Student student = students.Where(x => x.ID == ID).FirstOrDefault();
        return student;
    }

    public Task<List<Student>> GetList()
    {
        List <Student> students = new List<Student>();
        try
        {
            students.Add(new Student(10, "Luis David"));
            students.Add(new Student(20, "Mariangeles"));
            throw new Exception("My Exception");
        }
        catch (Exception ex)
        {

            Console.WriteLine("We have an exception " + ex.Message );
        }
       
        return Task.Run(()=> students); 
    }
}

public class Student
{
    public int ID { get; set; }
    public string Name { get; set; }

    public Student(int iD, string name)
    {
        ID = iD;
        Name = name;
    }

    public override string ToString()
    {
        return $"{ID} : {Name}";
    }
}