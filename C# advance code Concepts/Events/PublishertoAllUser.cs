using MainProgram;

namespace EventsPublishertoAllUser
{
    internal class PublishertoAllUser
    {
        //step 1 create delegate  naming convention append at end with EventHandler
        public delegate void publishNotificationEventHandler(object obj, EventArgs args);
        //step 2 create event handler
        public event publishNotificationEventHandler eventHandlerExecute;
        public void startPublishing()
        {
            Console.WriteLine("Started uploading the Content..");
            Thread.Sleep(4000);
            onEventHandlerExecute();
            Console.WriteLine("Completed uplaoding the content");

        }
        //step 3 raise the event naming should be protect , virtual and event name with prefix on
        protected virtual void onEventHandlerExecute()
        {
            if (eventHandlerExecute != null)
                eventHandlerExecute(this, EventArgs.Empty);
            // above line publish all the events to the subsribers 
        }
    }
}
