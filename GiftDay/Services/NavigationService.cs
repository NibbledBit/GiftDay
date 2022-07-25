using BitOfA.Helper.MVVM;
using GiftDay.Common;
using GiftDay.Views;

namespace GiftDay.Services {
    public class NavigationService : INavigationService {
        private readonly IServiceProvider serviceProvider;
        private readonly INavLookupService navLookup;

        public NavigationService(IServiceProvider serviceProvider, INavLookupService navLookup) {
            this.serviceProvider = serviceProvider;
            this.navLookup = navLookup;
        }

        IViewModel currentVm;
        public async Task Navigate<T>() where T : IViewModel {

            //var newV = navLookup.ConvertVMToV(typeof(T));

            //dynamic viewInstance = serviceProvider.GetService(newV);

            //viewInstance.ViewModel.OnAppearing();

            await Shell.Current.GoToAsync(typeof(T));
        }
    }
}
