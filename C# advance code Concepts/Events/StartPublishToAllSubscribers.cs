using EventsMailNotification;
using EventsPhoneNotification;
using EventsPublishertoAllUser;
using EventsWebSiteNotification;

namespace EventsStartPublishToAllSubscribers
{
    internal class StartPublishToAllSubscribers
    {
        public void start() { 
            PublishertoAllUser publish = new PublishertoAllUser();
            MailNotification m = new();
            PhoneNotification p = new();
            WebSiteNotification w = new();
            publish.eventHandlerExecute += m.notificationSent;
            publish.eventHandlerExecute += p.notificationSent;
            publish.eventHandlerExecute += w.notificationSent;
            publish.startPublishing();
         }

    }
}
