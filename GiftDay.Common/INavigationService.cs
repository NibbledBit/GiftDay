using BitOfA.Helper.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftDay.Common {
    public interface INavigationService : IService {
        Task Navigate<T>() where T : IViewModel;
    }

}
