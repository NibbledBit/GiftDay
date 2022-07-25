using BitOfA.Helper.MVVM;
using CommunityToolkit.Mvvm.ComponentModel;
using GiftDay.Services;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics.Metrics;
using System.Windows.Input;
using GiftDay.Domain;
using GiftDay.Common;

namespace GiftDay.ViewModels;

public partial class AddGiftEventViewModel : ViewModelBase {
    private readonly IEventsService events;

    [ObservableProperty]
    List<Domain.EventType> types = new List<EventType>() { EventType.Anniversary, EventType.Birthday, EventType.Custom };

    [ObservableProperty]
    string title;

    [ObservableProperty]
    EventType type;

    [ObservableProperty]
    DateTime eventDate;

    public AddGiftEventViewModel(INavigationService navigationService, IEventsService events) : base(navigationService) {
        this.events = events;
    }

    [RelayCommand]
    void Create() {
        events.CreateEvent(title, type, eventDate);
    }
}
