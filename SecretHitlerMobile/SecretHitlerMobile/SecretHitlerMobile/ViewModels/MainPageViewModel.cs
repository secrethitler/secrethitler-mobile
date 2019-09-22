using Prism.Commands;
using Prism.Navigation;
using System.Threading.Tasks;

namespace SecretHitlerMobile.ViewModels
{
	public class MainPageViewModel : ViewModelBase, INavigatedAware
	{
		private string _updateLandingPageLabel;
		private bool _canExecuteNavigation;

		private readonly INavigationService _navigationService;

		public DelegateCommand InitiateGame { get; private set; }

		public bool CanExecuteNavigation 
		{ 
			get => _canExecuteNavigation;
			set => SetProperty(ref _canExecuteNavigation, value);
		}

		public string UpdateLandingPageLabel
		{
			get => _updateLandingPageLabel;
			set => SetProperty(ref _updateLandingPageLabel, value);
		}

		public MainPageViewModel(INavigationService navigationService)
		: base(navigationService)
		{
			InitiateGame = new DelegateCommand(CreateGameLobbyExecute);
			_navigationService = navigationService;
		}

		private async Task NavigateToLobbyPage()
		{
			await _navigationService.NavigateAsync("LobbyPage");
		}

		private async void CreateGameLobbyExecute()
		{
			CanExecuteNavigation = false;
			await NavigateToLobbyPage();
			//var api = new ApiConnectionController(new HttpClient());
			//await api.CreateGameLobby();
			//UpdateLandingPageLabel = $"Response: {ApiConnectionController.RESPONSECONTENT} \n Successful: {ApiConnectionController.ISSUCCESSSTATUSCODE}";

		}

		public override void OnNavigatedFrom(INavigationParameters parameters)
		{
			CanExecuteNavigation = false;
		}

		public override void OnNavigatedTo(INavigationParameters parameters)
		{
			CanExecuteNavigation = parameters.GetValue<bool>("CanExecuteNavigation");
		}
	}
}
