namespace Concurrency.ThreadPropertiesDemo
{
    internal class ThreadProperites
    {
       
        public void PropertiesSample()
        {
            Thread t = new Thread(() => {
                for (int i = 0; i < 100; i++)
                    Console.Write(i);
            });
            t.Start();
            Thread t2 = Thread.CurrentThread;
            bool IsAlive = t.IsAlive;
            t.IsBackground = true;
            Console.WriteLine(t.ManagedThreadId);
            t2.Priority = ThreadPriority.Highest;
            ThreadState state = t2.ThreadState;
            bool IsThreadPool = t2.IsThreadPoolThread;
            
        }
    }
}
