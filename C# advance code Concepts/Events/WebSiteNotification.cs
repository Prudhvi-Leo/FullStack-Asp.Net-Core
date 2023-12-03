using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsWebSiteNotification
{
    internal class WebSiteNotification
    {
        public void notificationSent(object obj , EventArgs events)
        {
            Console.WriteLine("Website notification sent .. ");
        }
    }
}
