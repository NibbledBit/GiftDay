using BitOfA.Helper.MVVM;
using GiftDay.Common;
using GiftDay.Views;

namespace GiftDay.Services {
    public class NavigationService : INavigationService {
        private readonly INavLookupService navLookup;

        public NavigationService(INavLookupService navLookup) {
            this.navLookup = navLookup;
        }

        public async Task Navigate<T>() where T : IViewModel {

            var newV = navLookup.ConvertVMToV(typeof(T));
            var name = newV.Name;
            
            await Shell.Current.GoToAsync(name);
        }
    }
}
