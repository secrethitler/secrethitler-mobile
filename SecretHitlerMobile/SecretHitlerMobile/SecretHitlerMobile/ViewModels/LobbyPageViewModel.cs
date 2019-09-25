using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SecretHitlerMobile.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SecretHitlerMobile.ViewModels
{
	//Lobby Page ViewModel
	public class LobbyPageViewModel : BindableBase, INavigatedAware
	{

		private readonly INavigationService _navigationService;
		private string _lobbyIdLabelText;
		private string _userCount;
		private bool _canExecuteNavigationGameScreen;

		#region Properties

		public bool CanExecuteNavigationGameScreen
		{
			get => _canExecuteNavigationGameScreen;
			set => SetProperty(ref _canExecuteNavigationGameScreen, value);
		}
		public string UpdateLobbyIdLabel
		{
			get => _lobbyIdLabelText;
			set => SetProperty(ref _lobbyIdLabelText, value);
		}
		public string UserCount
		{
			get => _userCount;
			set => SetProperty(ref _userCount, value);
		}
		public static ICollection<User> UserList { get; set; }

		#endregion

		#region Commands

		public DelegateCommand NavigateToMainpage { get; private set; }
		public DelegateCommand NavigateToGameScreen { get; private set; }

		#endregion

		#region Contructors
		public LobbyPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			//bind Commands to Methods
			NavigateToMainpage = new DelegateCommand(async () => await NavigateToMainpageAsync());
			NavigateToGameScreen = new DelegateCommand(async () => await NavigateToGamePageAsync());
			SetUserCount(GetUserList());
			//testing purpose
			SetLobbyIdText("282938");
		}
		#endregion

		#region Methods

		/// <summary>
		/// Gets the UserList
		/// </summary>
		/// <returns>ObservableCollection of User</returns>
		public static ICollection<User> GetUserList()
		{
			//set for Test purposes
			return UserList ?? (UserList = new ObservableCollection<User>() {
					new User {
						Id = 3,
						Name = "Maxi"
					},
					new User {
						Id = 1,
						Name = "Pompori"
					},
					new User {
						Id = 2,
						Name = "Everesto"
					}
			});
		}

		public void SetUserCount(ICollection<User> users)
		{
			UserCount = "User (" + users.Count + "):";
		}

		public void SetLobbyIdText(string id)
		{
			UpdateLobbyIdLabel = "LobbyID: " + id;
		}

		private async Task NavigateToMainpageAsync()
		{
			var param = new NavigationParameters
			{
				{ "CanExecuteNavigationMainPage", true }
			};

			await _navigationService.GoBackAsync(param);

		}

		private async Task NavigateToGamePageAsync()
		{
			CanExecuteNavigationGameScreen = true;
			await _navigationService.NavigateAsync("GameScreen");
		}

		#endregion

		/// <summary>
		/// Called when the implementer has been navigated away from.
		/// </summary>
		/// <param name="parameters">The navigation parameters.</param>
		public void OnNavigatedFrom(INavigationParameters parameters)
		{
			CanExecuteNavigationGameScreen = false;
		}

		/// <summary>
		/// Called when the implementer has been navigated to.
		/// </summary>
		/// <param name="parameters">The navigation parameters.</param>
		public void OnNavigatedTo(INavigationParameters parameters)
		{
			CanExecuteNavigationGameScreen = parameters.GetValue<bool>("CanExecuteNavigationGameScreen");
		}
	}
}