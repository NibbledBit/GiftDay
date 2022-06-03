using BitOfA.Helper.MVVM;
using GiftDay.Services;
using System.Windows.Input;

namespace GiftDay.ViewModels;

public class AddPersonViewModel : ViewModelBase
{
    private readonly IPersonService personService;

    public AddPersonViewModel(IPersonService personService)
    {
        CreatePersonCommand = new Command(() => Create());
        this.personService = personService;
    }
    public ICommand CreatePersonCommand { get; set; }

    public void Create()
    {
        personService.CreatePerson();
    }
}
