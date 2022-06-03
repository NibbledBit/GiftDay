// See https://aka.ms/new-console-template for more information
using BitOfA.Helper.DDD;
using GiftDay.Persistence;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var optionsBuilder = new DbContextOptionsBuilder<GiftDayContext>();
optionsBuilder.UseSqlite("Data Source=GiftDayMigsDb.db");

var ctx = new GiftDayContext(optionsBuilder.Options, new NotifyDispatcher());



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