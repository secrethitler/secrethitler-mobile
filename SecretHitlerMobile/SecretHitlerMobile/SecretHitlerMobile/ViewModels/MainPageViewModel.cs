using Prism.Commands;
using Prism.Navigation;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Windows.Input;

namespace SecretHitlerMobile.ViewModels
{
	public class MainPageViewModel : ViewModelBase
	{
		private string _updateLandingPageLabel;

        private INavigationService _navigationService;
        // public DelegateCommand NavigateToLobbyPageCommand { get; private set; }


        public string UpdateLandingPageLabel{ 
			get { return _updateLandingPageLabel;}
			set { SetProperty(ref _updateLandingPageLabel, value); }
		}

        // public DelegateCommand StartCreateGameRequest { get; private set; }

        public DelegateCommand InitiateGame { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
		: base(navigationService)
		{
			InitiateGame = new DelegateCommand(CreateGameLobbyExecute);
            _navigationService = navigationService;
           // NavigateToLobbyPageCommand = new DelegateCommand(NavigateToLobbyPage);
        }

        private void NavigateToLobbyPage()
        {
            _navigationService.NavigateAsync("LobbyPage");
        }

        private async void CreateGameLobbyExecute()
		{
			//var api = new ApiConnectionController(new HttpClient());
            NavigateToLobbyPage();
   //         await api.CreateGameLobby();
			//UpdateLandingPageLabel = $"Response: {ApiConnectionController.RESPONSECONTENT} \n Successful: {ApiConnectionController.ISSUCCESSSTATUSCODE}";
   //         NavigateToLobbyPage();
		}
	}
}
