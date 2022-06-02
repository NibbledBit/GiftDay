using BitOfA.Helper.MVVM;
using GiftDay.Domain;
using GiftDay.Services;
using System.Reflection;

namespace GiftDay.ViewModels;

public class UpcomingEventsViewModel : IViewModel
{
    private readonly IEventsService events;

    public UpcomingEventsViewModel(IEventsService events)
    {
        this.events = events;
        MyEvents = GetEvents();

    }

    public IEnumerable<GiftEvent> GetEvents()
    {
        return events.GetEvents();
    }

    public IEnumerable<GiftEvent> MyEvents { get; set; }

}
