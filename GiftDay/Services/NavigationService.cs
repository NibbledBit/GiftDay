using GiftDay.Common;
using GiftDay.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftDay.Services {
    public class NavigationService : INavigationService {
        public async Task Navigate() {
            await Shell.Current.GoToAsync(nameof(AddEventView));
        }
    }
}
