/// <summary>
/// Is where two or more threads are unmoving or frozen in their execution because they are waiting for each other to finish
/// </summary>
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Main Method started");
        AtmDetail AtmOne = new AtmDetail(5000,501);
        AtmDetail AtmTwo = new AtmDetail(6000,502);

        AtmSystem atmSystem = new AtmSystem(AtmOne, AtmTwo, 200);
        Thread threadAtm = new Thread(atmSystem.Transfer2);
        threadAtm.Name = "threadAtm";
       


        AtmSystem atmSystem2 = new AtmSystem(AtmTwo, AtmOne, 1000);
        Thread threadAtm2 = new Thread(atmSystem2.Transfer2);
        threadAtm2.Name = "threadAtm2";

        threadAtm.Start();
        threadAtm2.Start();

        threadAtm.Join();
        threadAtm2.Join();

        Console.WriteLine($" AtmOne : {AtmOne.Balance}");
        Console.WriteLine($" AtmTwo : {AtmTwo.Balance}");
        Console.WriteLine("Main Method completed");
    }
}

public class AtmSystem
{
    AtmDetail _fromATM;
    AtmDetail _toATM;
    double _amountToTransfer;

    public AtmSystem(AtmDetail from, AtmDetail to, double amountToTransfer)
    {
        _fromATM = from;
        _toATM = to;
        _amountToTransfer = amountToTransfer;
    }
    /// <summary>
    /// this work because of  object bject, bject2
    /// we do not block _fromATM or _toATM instead of we block  bject or bject2
    /// </summary>
    public void Transfer()
    {
        Console.WriteLine($" {Thread.CurrentThread.Name} Is trying to access to lock {_fromATM.ID} ");
        object bject, bject2;
        if (_fromATM.ID < _toATM.ID)
        {
            bject = _fromATM;
            bject2 = _toATM;
        }
        else {
            bject = _toATM;
            bject2 = _fromATM;
        }

        lock (bject)
        {
            Console.WriteLine($" {Thread.CurrentThread.Name} trying to sleep fro 1 minute {((AtmDetail)bject).ID} ");
            Thread.Sleep (1000);
            //get form ATM Amount
            Console.WriteLine($" {Thread.CurrentThread.Name} Awake from sleep and trying to access to lock {_toATM.ID} ");
            lock (bject2)
            {
                Console.WriteLine($" {Thread.CurrentThread.Name} acquire lock on {((AtmDetail)bject2).ID}");
                Console.WriteLine($"The main logic to transfer it started");
                _fromATM.WithDraw(_amountToTransfer);
                _toATM.Deposit(_amountToTransfer);
            }
        }
    }

    public void Transfer2()
    {
        Console.WriteLine($" {Thread.CurrentThread.Name} Is trying to access to lock {_fromATM.ID} ");

        lock (_fromATM)
        {
            Console.WriteLine($" {Thread.CurrentThread.Name} trying to sleep fro 1 minute {_fromATM.ID} ");
            Thread.Sleep(1000);
            //get form ATM Amount
            Console.WriteLine($" {Thread.CurrentThread.Name} Awake from sleep and trying to access to lock {_toATM.ID} ");

            if (Monitor.TryEnter(_toATM, 3000))
            {

                try
                {
                    Console.WriteLine($" {Thread.CurrentThread.Name} acquire lock on {_toATM.ID}");
                    Console.WriteLine($"The main logic to transfer it started");
                    _fromATM.WithDraw(_amountToTransfer);
                    _toATM.Deposit(_amountToTransfer);
                }
                finally
                {
                    Console.WriteLine($" {Thread.CurrentThread.Name} has release {_toATM.ID}");
                    Monitor.Exit(_toATM);
                }
            }
            else
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} unable to acquire lock on {_toATM.ID}");
            }
        }
    }
}

public class AtmDetail
{
    double _balance;
    int _id;

    public AtmDetail(double balance, int id)
    {
        _balance = balance;
        _id = id;
    }

    public int ID
    { 
     get { return _id; }
    }
    public double Balance
    {
        get { return _balance; }
    }

    public void WithDraw(double amount)
    { 
      _balance -= amount;
    }

    public void Deposit(double balance)
    {
        _balance += balance;
    }
}