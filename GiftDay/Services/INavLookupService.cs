using BitOfA.Helper.MVVM;
using GiftDay.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftDay.Services {
    public interface INavLookupService {
        void Register<VM, V>()
            where V : IView<VM>
            where VM : IViewModel;

        Type ConvertVMToV(Type vm);
    }
    public class NavLookupService : INavLookupService {

        Dictionary<Type, Type> types;

        public NavLookupService() {
            types = new Dictionary<Type, Type>();
        }

        public Type ConvertVMToV(Type vm) {
            if (types.TryGetValue(vm, out Type type)) {
                return type;
            }
            throw new Exception($"There was no mapping for {vm}");
        }

        public void Register<VM, V>()
            where V : IView<VM>
            where VM : IViewModel {
            types.Add(typeof(VM), typeof(V));
        }
    }
}
