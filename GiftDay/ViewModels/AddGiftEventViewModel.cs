using BitOfA.Helper.MVVM;
using CommunityToolkit.Mvvm.ComponentModel;
using GiftDay.Services;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics.Metrics;
using System.Windows.Input;
using GiftDay.Domain;

namespace GiftDay.ViewModels;

public partial class AddGiftEventViewModel : ObservableObject, IViewModel {
    private readonly IEventsService events;

    [ObservableProperty]
    List<Domain.EventType> types = new List<EventType>() { EventType.Anniversary, EventType.Birthday, EventType.Custom };

    [ObservableProperty]
    string title;

    [ObservableProperty]
    EventType type;

    [ObservableProperty]
    DateTime eventDate;

    public AddGiftEventViewModel(IEventsService events)
    {
        this.events = events;
    }

    [RelayCommand]
    void Create() {
        events.CreateEvent(title, type, eventDate);
    }

    public void OnAppeared() {
    }

    public void OnAppearing() {
    }

    public void OnDisappearing() {
    }

    public void OnDispeared() {
    }
}
