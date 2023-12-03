using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsPhoneNotification
{
    internal class PhoneNotification
    {
        public void notificationSent(object obj, EventArgs events)
        {
            Console.WriteLine("Phone notification sent .. ");
        }
    }
}
