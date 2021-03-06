using BitOfA.Helper.MVVM;
using GiftDay.ViewModels;

namespace GiftDay.Views;

public partial class AddPersonView : ContentPage, IView<AddPersonViewModel>
{
    public IViewModel ViewModel { get; }
    public AddPersonView(AddPersonViewModel model)
    {
        BindingContext = model;
        ViewModel = model;
        InitializeComponent();
    }
}