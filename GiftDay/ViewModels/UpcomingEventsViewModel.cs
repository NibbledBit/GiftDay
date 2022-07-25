using BitOfA.Helper.MVVM;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GiftDay.Common;
using GiftDay.Models;
using GiftDay.Persistence;
using GiftDay.Services;
using GiftDay.Views;
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace GiftDay.ViewModels;

public partial class UpcomingEventsViewModel : ViewModelBase {
    private readonly IEventsService events;
    private readonly GiftDayContext context;
    private readonly INavLookupService navLookup;

    public UpcomingEventsViewModel(
        INavigationService navigationService, 
        IEventsService events, 
        GiftDayContext context,
        INavLookupService navLookup) 
        : base(navigationService) {

        navLookup.Register<AddGiftEventViewModel, AddEventView>();
        context.Database.Migrate();

        this.events = events;
        this.context = context;
        this.navLookup = navLookup;
        upcoming = new UpcomingEvents();
    }

    [RelayCommand]
    async Task Edit(UpcomingEventDto tapped) {
       await navigationService.Navigate<AddGiftEventViewModel>();
    }
    [RelayCommand]
    async Task Done(UpcomingEventDto tapped) {
        await Shell.Current.GoToAsync("AddEventPage");
    }

    public override void OnAppearing() {
        upcoming.Clear();
        foreach (var item in events.GetEvents()) {
            upcoming.Add(item);
        }
    }


    [ObservableProperty]
    UpcomingEvents upcoming;
}

public class UpcomingEvents : ObservableCollection<UpcomingEventDto>
{

}
