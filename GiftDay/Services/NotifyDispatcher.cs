using BitOfA.Helper.DDD;

namespace GiftDay.Services
{
    public class NotifyDispatcher : INotifyDispatcher
    {

        IList<INotifySubscriber<INotification>> subscribers;

        public NotifyDispatcher()
        {
            subscribers = new List<INotifySubscriber<INotification>>();
        }

        public void Dispatch(INotification domainEvent)
        {
            //throw new NotImplementedException();
        }

        public void Subscribe<S>()
            where S : INotifySubscriber<INotification>, new()
        {
            subscribers.Add(new S());
        }
    }
}
