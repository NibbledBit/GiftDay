using BitOfA.Helper.MVVM;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GiftDay.Models;
using GiftDay.Persistence;
using GiftDay.Services;
using GiftDay.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace GiftDay.ViewModels;

public partial class UpcomingEventsViewModel : ObservableObject, IViewModel {
    private readonly IEventsService events;
    private readonly GiftDayContext context;

    public UpcomingEventsViewModel(IEventsService events, GiftDayContext context) {
        context.Database.Migrate();

        this.events = events;
        this.context = context;

        upcoming = new UpcomingEvents();
    }

    [RelayCommand]
    async Task Edit(UpcomingEventDto tapped) {
        await Shell.Current.GoToAsync(nameof(AddEventView));
    }
    [RelayCommand]
    async Task Done(UpcomingEventDto tapped) {
        await Shell.Current.GoToAsync("AddEventPage");
    }

    public void OnAppearing() {
        upcoming.Clear();
        foreach (var item in events.GetEvents()) {
            upcoming.Add(item);
        }
    }

    public void OnAppeared() {
    }

    public void OnDisappearing() {
    }

    public void OnDispeared() {
    }

    [ObservableProperty]
    UpcomingEvents upcoming;
}

public class UpcomingEvents : ObservableCollection<UpcomingEventDto>
{

}
