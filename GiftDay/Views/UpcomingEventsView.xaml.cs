using GiftDay.ViewModels;

namespace GiftDay.Views;

public partial class UpcomingEventsView : ContentPage
{
    public UpcomingEventsView(UpcomingEventsViewModel model)
    {
        BindingContext = model;
        InitializeComponent();
    }
}