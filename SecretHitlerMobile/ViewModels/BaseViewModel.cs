using Prism.Mvvm;
using Prism.Navigation;

namespace SecretHitlerMobile.ViewModels
{
    public abstract class BaseViewModel : BindableBase, INavigationAware
    {
        protected BaseViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }

        protected INavigationService NavigationService { get; }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public void OnNavigatingTo(INavigationParameters parameters)
        {
        }
    }
}