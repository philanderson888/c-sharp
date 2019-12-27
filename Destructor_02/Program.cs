using System;
using System.Diagnostics;

public class Destructor_02
{
    Stopwatch sw;

    public Destructor_02()
    {
        sw = Stopwatch.StartNew();
        Console.WriteLine("Instantiated object");
    }

    public void ShowDuration()
    {
        Console.WriteLine("This instance of {0} has been in existence for {1}",
                          this, sw.Elapsed);
    }

    ~Destructor_02()
    {
        Console.WriteLine("Finalizing object");
        sw.Stop();
        Console.WriteLine("This instance of {0} has been in existence for {1}",
                          this, sw.Elapsed);
    }
}

public class Demo
{
    public static void Main()
    {
        Destructor_02 ex = new Destructor_02();
        ex.ShowDuration();
    }
}


// The example displays output like the following:
//    Instantiated object
//    This instance of ExampleClass has been in existence for 00:00:00.0011060
//    Finalizing object
//    This instance of ExampleClass has been in existence for 00:00:00.0036294
