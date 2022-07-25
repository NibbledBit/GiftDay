using BitOfA.Helper.MVVM;
using CommunityToolkit.Mvvm.ComponentModel;
using GiftDay.Common;

namespace GiftDay.ViewModels; 
public abstract class ViewModelBase : ObservableObject, IViewModel {
	private readonly INavigationService navigationService;

	public ViewModelBase(INavigationService navigationService) {
		this.navigationService = navigationService;
	}

	public virtual void OnAppeared() {
	}

    public virtual void OnAppearing() {
	}

    public virtual void OnDisappearing() {
	}

    public virtual void OnDispeared() {
	}
}
