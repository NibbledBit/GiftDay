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

    protected override void OnAppearing()
    {
        ViewModel.OnAppearingAsync();
        base.OnAppearing();
    }

    protected override void OnDisappearing()
    {
        ViewModel.OnDisappearing();
        base.OnDisappearing();
    }
}