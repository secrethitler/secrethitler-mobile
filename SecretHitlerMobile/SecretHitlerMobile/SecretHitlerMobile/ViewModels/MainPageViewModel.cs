using Prism.Commands;
using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using SecretHitlerMobile.Models;
using SecretHitlerMobile.Views;
using System.Threading.Tasks;

namespace SecretHitlerMobile.ViewModels
{
	//Main Page ViewModel
	public class MainPageViewModel : ViewModelBase, INavigatedAware
	{
		private readonly INavigationService _navigationService;
		private string _updateLandingPageLabel;
		private bool _canExecuteNavigationMainpage;

		#region Commands
		public DelegateCommand InitiateGame { get; private set; }
		public DelegateCommand NavigateToLobby { get; private set; }
		#endregion

		#region Properties
		public bool CanExecuteNavigationMainpage
		{
			get => _canExecuteNavigationMainpage;
			set => SetProperty(ref _canExecuteNavigationMainpage, value);
		}

		public string UpdateLandingPageLabel
		{
			get => _updateLandingPageLabel;
			set => SetProperty(ref _updateLandingPageLabel, value);
		}
		#endregion

		#region Constructors
		public MainPageViewModel(INavigationService navigationService)
		: base(navigationService)
		{
			//bind commands
			InitiateGame = new DelegateCommand(OnCreateGameOpenAsync);
			NavigateToLobby = new DelegateCommand(CreateGameLobbyExecute);
			_navigationService = navigationService;
		}
		#endregion

		#region Methods
		private async void CreateGameLobbyExecute()
		{
			await PopupNavigation.Instance.PopAllAsync();
			await NavigateToLobbyPage();
		}

		private async Task NavigateToLobbyPage()
		{
			CanExecuteNavigationMainpage = false;
			await _navigationService.NavigateAsync("LobbyPage");
		}

		private async void OnCreateGameOpenAsync()
		{
			var createGamePopup = new CreateGamePopup();
			await PopupNavigation.Instance.PushAsync(createGamePopup);
		}

		#endregion

		/// <summary>
		/// Called when the implementer has been navigated away from.
		/// </summary>
		/// <param name="parameters">The navigation parameters.</param>
		public override void OnNavigatedFrom(INavigationParameters parameters)
		{
			CanExecuteNavigationMainpage = false;
		}

		/// <summary>
		/// Called when the implementer has been navigated to.
		/// </summary>
		/// <param name="parameters">The navigation parameters.</param>
		public override void OnNavigatedTo(INavigationParameters parameters)
		{
			CanExecuteNavigationMainpage = parameters.GetValue<bool>("CanExecuteNavigation");
		}
	}
}
