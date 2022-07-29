using BitOfA.Helper.MVVM;
using CommunityToolkit.Mvvm.ComponentModel;
using GiftDay.Common;

namespace GiftDay.ViewModels; 
public abstract class ViewModelBase : ObservableObject, IViewModel {
	protected readonly INavigationService navigationService;

	public ViewModelBase(INavigationService navigationService) {
		this.navigationService = navigationService;
	}

	public virtual Task OnAppeared() {
	}

    public virtual Task OnAppearingAsync() {
	}

    public virtual Task OnDisappearing() {
	}

    public virtual Task OnDispeared() {
	}
}
