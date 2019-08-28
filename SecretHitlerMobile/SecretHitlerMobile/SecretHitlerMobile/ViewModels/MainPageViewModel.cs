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


		public string UpdateLandingPageLabel{ 
			get { return _updateLandingPageLabel;}
			set { SetProperty(ref _updateLandingPageLabel, value); }
		}

		public DelegateCommand ExecuteTestCommand { get; private set; }

		public MainPageViewModel(INavigationService navigationService)
		: base(navigationService)
		{
			ExecuteTestCommand = new DelegateCommand(CreateGameLobbyExecute);
		}

		private async void CreateGameLobbyExecute()
		{
			var api = new ApiConnectionController(new HttpClient());
			await api.CreateGameLobby();
			UpdateLandingPageLabel = $"Response: {ApiConnectionController.RESPONSECONTENT} \n Successful: {ApiConnectionController.ISSUCCESSSTATUSCODE}";
		}
	}
}
