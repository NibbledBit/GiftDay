using BitOfA.Helper.MVVM;
using CommunityToolkit.Mvvm.ComponentModel;
using GiftDay.Common;
using GiftDay.Services;
using System.Windows.Input;

namespace GiftDay.ViewModels;

public partial class AddPersonViewModel : ViewModelBase {
    private readonly IPersonService personService;

    [ObservableProperty]
    string name;

    [ObservableProperty]
    bool celebrateBirthday;
    [ObservableProperty]
    DateTime? birthdayDate;

    [ObservableProperty]
    bool celebrateChristmas;

    [ObservableProperty]
    bool celebrateAnniversary;
    [ObservableProperty]
    DateTime? anniversaryDate;

    public AddPersonViewModel(INavigationService navigationService, IPersonService personService) : base(navigationService) {
        CreatePersonCommand = new Command(() => Create());
        this.personService = personService;
    }
    public ICommand CreatePersonCommand { get; set; }

    public void Create() {

        string firstName = GetFirstName();
        string lastName = GetLastName();

        var person = personService.CreatePerson(firstName, lastName);

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
