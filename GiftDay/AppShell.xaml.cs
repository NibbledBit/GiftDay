using GiftDay.Views;

namespace GiftDay;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute(nameof(AddEventView), typeof(AddEventView));
    }
}
