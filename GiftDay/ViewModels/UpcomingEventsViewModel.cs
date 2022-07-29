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
    Task Done(UpcomingEventDto tapped) {
        //TODO: Mark the event as done
        return Task.CompletedTask;
    }

    public override async Task OnAppearing() {
        upcoming.Clear();
        foreach (var item in await events.GetEvents()) {
            upcoming.Add(item);
        }
    }

    [ObservableProperty]
    ObservableCollection<UpcomingEventDto> upcoming;
}