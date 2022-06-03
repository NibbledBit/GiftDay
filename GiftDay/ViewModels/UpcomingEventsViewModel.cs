using BitOfA.Helper.MVVM;
using GiftDay.Models;
using GiftDay.Persistence;
using GiftDay.Services;
using Microsoft.EntityFrameworkCore;

namespace GiftDay.ViewModels;

public class UpcomingEventsViewModel : ViewModelBase
{
    private readonly IEventsService events;
    private readonly GiftDayContext context;

    public UpcomingEventsViewModel(IEventsService events, GiftDayContext context)
    {
        context.Database.Migrate();


        this.events = events;
        this.context = context;
        MyEvents = events.GetEvents();
    }

    public IEnumerable<UpcomingEventDto> MyEvents { get; set; }

}
