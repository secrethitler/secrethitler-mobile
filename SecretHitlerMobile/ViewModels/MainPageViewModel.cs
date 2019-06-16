using Prism.Navigation;

namespace SecretHitlerMobile.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        private bool _isAuthenticating;

        public MainPageViewModel(INavigationService navigationService) : base(navigationService)
        {
            IsAuthenticating = true;
        }


        public bool IsAuthenticating
        {
            get => _isAuthenticating;
            set => SetProperty(ref _isAuthenticating, value);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Authenticate();

            base.OnNavigatedTo(parameters);
        }

        public void Authenticate()
        {
        }
    }
}