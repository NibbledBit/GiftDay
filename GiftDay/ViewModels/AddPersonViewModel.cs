using BitOfA.Helper.MVVM;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GiftDay.Common;
using GiftDay.Services;
using System.Windows.Input;

namespace GiftDay.ViewModels;

public partial class AddPersonViewModel : ViewModelBase {
    private readonly IPersonService personService;
    private readonly IEventsService events;
    [ObservableProperty]
    string name;

    [ObservableProperty]
    bool celebrateBirthday;
    [ObservableProperty]
    DateTime birthdayDate;

    [ObservableProperty]
    bool celebrateChristmas;

    [ObservableProperty]
    bool celebrateAnniversary;
    [ObservableProperty]
    DateTime anniversaryDate;

    public AddPersonViewModel(INavigationService navigationService, IPersonService personService, IEventsService events) : base(navigationService) { 
        this.personService = personService;
        this.events = events;

        ResetUi();
    }

    private void ResetUi() {
        Name = string.Empty;
        CelebrateBirthday = false;
        CelebrateChristmas = false;
        CelebrateAnniversary = false;
        BirthdayDate = DateTime.Today;
        AnniversaryDate = DateTime.Today;
    }


    [RelayCommand]
    public async Task CreatePerson() {

        string firstName = GetFirstName();
        string lastName = GetLastName();

        var person = await personService.CreatePerson(firstName, lastName);

        if (celebrateBirthday) {
            await events.CreateEvent(person.Id, Domain.EventType.Birthday, birthdayDate);
        }
        if (celebrateChristmas) {
            var now = DateTime.Now;
            var xmas = new DateTime(now.Year, 12, 25);
            await events.CreateEvent(person.Id, Domain.EventType.Christmas, xmas);
        }
        if (celebrateAnniversary) {
            await events.CreateEvent(person.Id, Domain.EventType.Anniversary, anniversaryDate);
        }


        ResetUi();
        await navigationService.GoHome();
    }

    private string GetLastName() {
        if (name.Contains(' ')) {
            return name.Split(' ')[1];
        }
        else {
            return string.Empty;
        }
    }

    private string GetFirstName() {
        if (name.Contains(' ')) {
            return name.Split(' ')[0];
        }
        else {
            return name;
        }
    }
}
