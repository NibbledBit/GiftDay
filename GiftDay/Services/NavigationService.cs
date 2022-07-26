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

            var newV = navLookup.ConvertVMToV(typeof(T));


            //viewInstance.ViewModel.OnAppearing();
            var name = newV.Name;

            await Shell.Current.GoToAsync(name);
        }
    }
}
