using BitOfA.Helper.MVVM;
using GiftDay.Models;
using GiftDay.Persistence;
using GiftDay.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

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

        MyEvents = new UpcomingEvents();
    }

    public override void OnAppearing()
    {
        MyEvents.Clear();
        foreach (var item in events.GetEvents())
        {
            MyEvents.Add(item);
        }
    }

    public UpcomingEvents MyEvents { get; set; }

}

public class UpcomingEvents : List<UpcomingEventDto>
{

}
