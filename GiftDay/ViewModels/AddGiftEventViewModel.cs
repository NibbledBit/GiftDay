using BitOfA.Helper.MVVM;
using CommunityToolkit.Mvvm.ComponentModel;
using GiftDay.Services;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics.Metrics;
using System.Windows.Input;
using GiftDay.Domain;
using GiftDay.Common;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GiftDay.ViewModels;

public partial class AddGiftEventViewModel : ViewModelBase {
    private readonly IEventsService events;

    //put enums on a page
    //[ObservableProperty]
    //List<Domain.EventType> types = new List<EventType>() { EventType.Anniversary, EventType.Birthday, EventType.Custom };

    [ObservableProperty]
    string title;

    [ObservableProperty]
    DateTime eventDate;

    public AddGiftEventViewModel(INavigationService navigationService, IEventsService events) : base(navigationService) {

        this.events = events;

        eventDate = DateTime.Today;
    }


    [RelayCommand]
    void Create() {
        events.CreateEvent(title, EventType.Custom, eventDate);
    }
}
