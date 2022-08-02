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

    [ObservableProperty]
    ObservableCollection<UpcomingEventDto> upcoming;

    public UpcomingEventsViewModel(
        INavigationService navigationService, 
        IEventsService events) 
        : base(navigationService) {

        this.events = events;
        upcoming = new ObservableCollection<UpcomingEventDto>();
    }

    [RelayCommand]
    Task Edit(UpcomingEventDto tapped) {
        //TODO: Go to an edit page
        return Task.CompletedTask;
    }
    [RelayCommand]
    async Task Done(UpcomingEventDto tapped) {
        await events.MarkGiftIsBought(tapped.Id, !tapped.GiftBought);
    }

    public override async Task OnAppearing() {
        upcoming.Clear();
        foreach (var item in await events.GetEvents()) {
            upcoming.Add(item);
        }
    }
}