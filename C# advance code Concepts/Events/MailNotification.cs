using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsMailNotification { 
    internal class MailNotification
{
    public void notificationSent(object obj, EventArgs events)
    {
            Console.WriteLine("Mail notification sent .. ");
        }
}

}
