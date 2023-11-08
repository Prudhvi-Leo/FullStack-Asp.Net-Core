using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conurrency.ThreadMethodsDemo
{
    internal class ThreadMethods
    {
        public void Practice()
        {
           
          
           
        }
       
        public void JoinExample()
        {
            Thread t = new Thread(() =>
            {
                Console.WriteLine("Loading....");
                
                Thread.Sleep(5000);

            });
            t.Start();
            t.Join();
            Console.WriteLine($"Main completed wating for {t.ManagedThreadId} to be completed ");

        }
        public void AbortMethodExample()
        {
            Thread thread = new Thread(WorkerMethod);
            thread.Start();

            // Allow the thread to run for a while
            Thread.Sleep(2000);

            // Now, abort the thread
            thread.Abort();
        }
        public void InterupptedExample()
        {
            Thread workerThread = new Thread(WorkerMethodInterrupt);
            workerThread.Start();

            // Sleep for a while to allow the thread to run
            Thread.Sleep(2000);
            Console.WriteLine("Main Thread Completed wiating for 2 secs");
            // Interrupt the worker thread
            workerThread.Interrupt();
           
        }
        static void WorkerMethodInterrupt()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Working...");
                    Thread.Sleep(10000);
                    Console.WriteLine("I Got Interrupted boiii");
                }
            }
            catch (ThreadInterruptedException)
            {
                // Handle the interruption if needed
                Console.WriteLine("Thread has been interrupted.");
            }
        }
        static void WorkerMethod()
        {
            try
            {
                while (true)
                {
                    // Perform some work
                    Console.WriteLine("Working...");
                    Thread.Sleep(1000);
                }
            }
            catch (ThreadAbortException)
            {
                // Handle the thread abort if needed
                Console.WriteLine("Thread has been aborted.");
            }
        }
    }
}
