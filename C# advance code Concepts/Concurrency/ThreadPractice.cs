using Concurrency.ThreadPropertiesDemo;
using Conurrency.ThreadMethodsDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadsPracticeDemo.Concurrency
{
    internal class ThreadPractice
    {
        public void solve()
        {
            /* ThreadProperites TestThread = new ThreadProperites();
             TestThread.PropertiesSample(); */
            ThreadMethods TestMethods = new ThreadMethods();
            TestMethods.Practice();
            // TestMethods.AbortMethodExample();
            //TestMethods.InterupptedExample();

            //TestMethods.JoinExample();

        }

    }
}
