using BitOfA.Helper.MVVM;
using GiftDay.ViewModels;

namespace GiftDay.Views;

public partial class AddEventView : ContentPage, IView<AddGiftEventViewModel>
{
    public IViewModel ViewModel { get; }
    public AddEventView(AddGiftEventViewModel model)
    {
        BindingContext = model;
        ViewModel = model;
        InitializeComponent();
	}

}