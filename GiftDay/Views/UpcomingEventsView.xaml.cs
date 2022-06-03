using GiftDay.ViewModels;
using BitOfA.Helper.MVVM;
namespace GiftDay.Views;

public partial class UpcomingEventsView : ContentPage, IView<UpcomingEventsViewModel>
{

    public IViewModel ViewModel { get; }

    public UpcomingEventsView(UpcomingEventsViewModel model)
    {
        BindingContext = model;
        ViewModel = model; 
        InitializeComponent();

    }

    protected async override void OnAppearing()
    {
        await ViewModel.OnAppearing();
        base.OnAppearing();
    }

    protected async override void OnDisappearing()
    {
        await ViewModel.OnDisappearing();
        base.OnDisappearing();
    }
}