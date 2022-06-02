using BitOfA.Helper.MVVM;
using GiftDay.Models;
using GiftDay.Services;

namespace GiftDay.ViewModels;

public class UpcomingEventsViewModel : IViewModel
{
    private readonly IEventsService events;

    public UpcomingEventsViewModel(IEventsService events)
    {
        this.events = events;
    }

    public async Task OnLoading()
    {
        MyEvents = await events.GetEvents();
    }

    public IEnumerable<UpcomingEventDto> MyEvents { get; set; }

}
