using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MutexDemoExample
{
    internal class MutexExample
    {
        private static Mutex mutex = new Mutex(true);
        public void CreateThread()
        {
            for(int i=0;i< 10; i++)
            new Thread(MutexExample.solve).Start();
        }
        public static void solve()
        {
      
                bool value = false;
                if(mutex.WaitOne(5000 ,  value))
                Console.WriteLine("Hello world");
                Thread.Sleep(TimeSpan.FromSeconds(0));
                mutex.ReleaseMutex();
         
        }
    }
}
