using BitOfA.Helper.DDD;
using GiftDay.Common;

namespace GiftDay.Services
{
    public class NotifyDispatcher : INotifyDispatcher, IService
    {

        IList<INotifySubscriber<INotification>> subscribers;

        public NotifyDispatcher(IServiceProvider sp)
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
