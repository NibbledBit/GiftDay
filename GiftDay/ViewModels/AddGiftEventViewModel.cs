using BitOfA.Helper.MVVM;
using GiftDay.Services;
using System.Windows.Input;

namespace GiftDay.ViewModels;

public class AddGiftEventViewModel : ViewModelBase
{
    private readonly IEventsService events;

    public AddGiftEventViewModel(IEventsService events)
    {
        CreateEventCommand = new Command(() => Create());
        this.events = events;
    }
    public ICommand CreateEventCommand { get; set; }

    public void Create()
    {
        events.CreateEvent("My New Event", Domain.EventType.Birthday, new DateTime(1987, 11, 11));
    }
}
