using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GiftDay.Common;
using GiftDay.Domain;
using GiftDay.Services;

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

    public AddGiftEventViewModel(INavigationService navigationService, IEventsService events)
        : base(navigationService) {
        this.events = events;

        ResetUi();
    }

    [RelayCommand]
    async Task CreateEvent() {
        var ev = await events.CreateEvent(title, EventType.Custom, eventDate);
        ResetUi();
        await navigationService.GoHome();
    }

    private void ResetUi() {
        Title = string.Empty;
        EventDate = DateTime.Today;
    }
}
