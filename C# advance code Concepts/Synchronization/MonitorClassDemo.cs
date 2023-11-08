using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorDemo.Synchronization
{
    internal class MonitorClassDemo
    {
        private static int NumberOfTickets = 500;
        private static readonly object locker = new object();
        private static readonly TimeSpan time = TimeSpan.FromMilliseconds(1);

        public void BookTicket()
        {
            for (int i = 1; i < 50; i++)
            {
                Thread t = new Thread(MonitorClassDemo.TicketConformation);
                t.Name = $"User {i}";
                t.Start();
            }

        }
        public static void TicketConformation()
        {
            bool isTaken = false;
            Console.WriteLine(Thread.CurrentThread.Name + " Entered To Book Tickets");
            try
            {

                Monitor.TryEnter(locker, time, ref isTaken);
                if (isTaken)
                {
                    if (NumberOfTickets > 0) {
                        Console.WriteLine(Thread.CurrentThread.Name + " Booked Ticket");
                        NumberOfTickets--;
                        if (NumberOfTickets == 0)
                            throw new  ShowIsFull("Thanks for visiting show is Full");
                    }
                    else
                    {
                        Console.WriteLine(Thread.CurrentThread.Name + " Sorry show is FULL Thanks for visiting");
                        NumberOfTickets = -2;
                    }
                }
                else
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " Time Expired");
                }
            }
            catch(ShowIsFull ex)
            {
                
                   
                Console.WriteLine(ex.Message);
                NumberOfTickets = -1;
            }
            finally
            {
                if (isTaken)
                {
                    if (NumberOfTickets == -2)
                        Console.WriteLine(Thread.CurrentThread.Name + " Sorry show is FULL Thanks for visiting");
                    else
                        Console.WriteLine(Thread.CurrentThread.Name + " Thanks For booking Ticket visit Again");
                    Monitor.Exit(locker);
                }
            }
        }
        class ShowIsFull : Exception
        {
            public ShowIsFull() { }
            public ShowIsFull(string message) : base(message){
            }
           
        }
    }
}
