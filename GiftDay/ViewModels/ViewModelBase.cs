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
		return Task.CompletedTask;
	}

    public virtual Task OnAppearing() {
        return Task.CompletedTask;
    }

    public virtual Task OnDisappearing() {
        return Task.CompletedTask;
    }

    public virtual Task OnDispeared() {
        return Task.CompletedTask;
    }
}
