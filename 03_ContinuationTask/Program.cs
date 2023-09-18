internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        // the last one result type <string>
        Task<string> taskGetStudenId = Task.Run(() =>
        {
            return GetStudenId(5); // return int: student ID to search
        })
        .ContinueWith(studenId =>
        {
            return GetOne(studenId.Result); // return Student Object: Student info

        })
        .ContinueWith(studentInfo =>
        {
            return studentInfo.Result.ToString(); // return Student info string format

        });

        Console.WriteLine($"User information => {taskGetStudenId.Result}");

        Console.ReadLine();
    }

    static int GetStudenId(int max)
    {
        return 10;
    }

    static Student GetOne(int id)
    {
        return new Student() { ID = 100005785, Name = "Luis David Martinez" };
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