using MutexDemoExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SemaphoreDEMO
{
    internal class SemaphoreClass
    {
        static Semaphore semaphore = new Semaphore(0, 3);
        public void CreateThread()
        {
            for (int i = 1; i <= 10; i++)
            {
                Thread threadObject = new Thread(solve)
                {
                    Name = "Thread " + i
                };
                threadObject.Start();
            }
        }
        public static void solve()
        {

            Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter into Critical Section for processing");
            using (Semaphore s = new Semaphore(0, 3))
            {
               
                //Blocks the current thread until the current WaitHandle receives a signal.   
               

               
                    //Decrease the Initial Count Variable by 1
                    Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Doing its work");
                    Thread.Sleep(1000);
                    Console.WriteLine(Thread.CurrentThread.Name + "Exit.");
               
            }

        }
    }
}
