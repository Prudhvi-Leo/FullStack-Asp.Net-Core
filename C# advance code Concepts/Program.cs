using System.Threading;
using System;
using System.Diagnostics;
using System.ComponentModel;

namespace MainProgram
{

    class Program
    {
        static Semaphore s = new Semaphore(1, 3); // Initial count: 1, Maximum count: 3

        static void Main()
        {
            for (int i = 1; i <= 5; i++)
            {
                Thread t = new Thread(DoWork);
                t.Name = $"Thread {i}";
                t.Start();
            }

            Console.ReadLine(); // Keep the console open
        }

        static void DoWork()
        {
            Console.WriteLine($"{Thread.CurrentThread.Name} trying to enter.");
            s.WaitOne(); // Acquire the semaphore

            Console.WriteLine($"{Thread.CurrentThread.Name} entered the critical section.");
            Thread.Sleep(2000); // Simulate some work inside the critical section

            Console.WriteLine($"{Thread.CurrentThread.Name} exiting the critical section.");
            s.Release(); // Release the semaphore
        }
    }

}


