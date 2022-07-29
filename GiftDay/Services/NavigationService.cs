using BitOfA.Helper.MVVM;
using GiftDay.Common;
using GiftDay.Views;
using static Java.Util.Jar.Attributes;

namespace GiftDay.Services {
    public class NavigationService : INavigationService {
        private readonly INavLookupService navLookup;

        public NavigationService(INavLookupService navLookup) {
            this.navLookup = navLookup;
        }

        public async Task GoBack() {
            await Shell.Current.GoToAsync("..");
        }

        public async Task GoHome() {
            await Shell.Current.GoToAsync("//Home");
        }

        public async Task Navigate<T>() where T : IViewModel {

            var newV = navLookup.ConvertVMToV(typeof(T));
            var name = newV.Name;
            
            await Shell.Current.GoToAsync(name);
        }
    }
}
