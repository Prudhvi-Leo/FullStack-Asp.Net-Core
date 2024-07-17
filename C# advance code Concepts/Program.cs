using System.Threading;
using System;
using System.Diagnostics;
using System.ComponentModel;
using C__advance_code_Concepts;
using EventsPhoneNotification;
using EventsStartPublishToAllSubscribers;
using testClassBinding;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Dynamic;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace MainProgram
{
    class Program
    {
        public static void Main(string[] args)
        {

            C c = new C();
            c.solve();
        }
        
        abstract class A
        {
            public abstract void execute();
            public abstract void execute(int a);
            public void solve()
            {
                execute();
                execute(4);
            }

        }
        class B : A
        {
           
            public override void execute()
            {
                Console.WriteLine("Inside the class B");
            }

            public override void execute(int a)
            {
                 execute(a);
            }
        }
        class C : B
        {
           public override void execute(int a)
            {
                Console.WriteLine(a);
            }
            

        }

    }
   

    

}






