using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicLockExampleDemo
{
    internal class LockDemoExample
    {
        public void ThreadCreation()
        {

            BookMyShow bookMyShow = new BookMyShow();
            Thread t1 = new Thread(bookMyShow.TicketBookig)
            {
                Name = "Thread1"
            };
            Thread t2 = new Thread(bookMyShow.TicketBookig)
            {
                Name = "Thread2"
            };
            Thread t3 = new Thread(bookMyShow.TicketBookig)
            {
                Name = "Thread3"
            };

            t1.Start();
            t2.Start();
            t3.Start();
            Console.ReadKey();
        }
        public class BookMyShow
        {
            private object lockObject = new object();
            int AvailableTickets = 3;
            static int i = 1, j = 2, k = 3;
            public void BookTicket(string name, int wantedtickets)
            {
                lock (lockObject)
                {
                    if (wantedtickets <= AvailableTickets)
                    {
                        Console.WriteLine(wantedtickets + " booked to " + name);
                        AvailableTickets = AvailableTickets - wantedtickets;
                    }
                    else
                    {
                        Console.WriteLine("No tickets Available to book");
                    }
                }
            }
            public void TicketBookig()
            {
                string name = Thread.CurrentThread.Name;
                if (name.Equals("Thread1"))
                {
                    BookTicket(name, i);
                }
                else if (name.Equals("Thread2"))
                {
                    BookTicket(name, j);
                }
                else
                {
                    BookTicket(name, k);
                }
            }
        }

    }
}
