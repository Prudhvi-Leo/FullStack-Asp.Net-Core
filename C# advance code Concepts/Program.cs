using System.Threading;
using System;
using System.Diagnostics;
using System.ComponentModel;
using C__advance_code_Concepts;
using EventsPhoneNotification;
using EventsStartPublishToAllSubscribers;

namespace MainProgram
{
    public delegate int DelegateTest(int a, int b);
    class Program
    {
       
        static void Main()
        {
            StartPublishToAllSubscribers sb = new StartPublishToAllSubscribers();
            sb.start();
        }
        
    }
}



