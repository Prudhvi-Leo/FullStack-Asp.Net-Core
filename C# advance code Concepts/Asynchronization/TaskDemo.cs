using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TaskCreationDemo
{
    internal class TaskDemo
    {
        public static void Method() {
            solve();

            Action<object> action = (object obj) =>
            {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                Task.CurrentId, obj,
                Thread.CurrentThread.ManagedThreadId);
            };

            // Create a task but do not start it.
            Task t1 = new Task(action, "alpha");

            // Construct a started task
            Task t2 = Task.Factory.StartNew(action, "beta");
            // Block the main thread to demonstrate that t2 is executing
            t2.Wait();

            // Launch t1 
            t1.Start();
            Console.WriteLine("t1 has been launched. (Main Thread={0})",
                              Thread.CurrentThread.ManagedThreadId);
            // Wait for the task to finish.
            t1.Wait();

            // Construct a started task using Task.Run.
            String taskData = "delta";
            Task t3 = Task.Run(() => {
                Console.WriteLine("Task={0}, obj={1}, Thread={2}",
                                                         Task.CurrentId, taskData,
                                                          Thread.CurrentThread.ManagedThreadId);
            });
            // Wait for the task to finish.
            t3.Wait();

            // Construct an unstarted task
            Task t4 = new Task(action, "gamma");
            // Run it synchronously
            t4.RunSynchronously();
            // Although the task was run synchronously, it is a good practice
            // to wait for it in the event exceptions were thrown by the task.
            t4.Wait();
        }
        public static void solve()
        {
            Task t = Task.Run(() =>
            {
                Console.WriteLine("{0} {1}", Task.CurrentId, 100);
            });

            Task t2 = new Task(() => {
                Task.Delay(4000);
                Console.WriteLine("{0} {1}", Task.CurrentId, 200);
            });
            t2.Start();


        }
        static async void LongProcess()
        {
            Console.WriteLine("LongProcess Started");

            await Task.Delay(4000); // hold execution for 4 seconds

            Console.WriteLine("LongProcess Completed");

        }

        static void ShortProcess()
        {
            Console.WriteLine("ShortProcess Started");

            //do something here

            Console.WriteLine("ShortProcess Completed");
        }
    }
}
