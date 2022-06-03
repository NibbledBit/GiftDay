using GiftDay.ViewModels;
using BitOfA.Helper.MVVM;
namespace GiftDay.Views;

public partial class UpcomingEventsView : ContentPage//, IView<UpcomingEventsViewModel>
{
    IViewModel ViewModel { get; }


    public UpcomingEventsView(UpcomingEventsViewModel model)
    {
        BindingContext = model;
        ViewModel = model; 
        InitializeComponent();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }
}