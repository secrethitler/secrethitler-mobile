using Prism.Navigation;

namespace SecretHitlerMobile.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public string UserName { get; set; }

        public string Password { get; set; }
    }
}