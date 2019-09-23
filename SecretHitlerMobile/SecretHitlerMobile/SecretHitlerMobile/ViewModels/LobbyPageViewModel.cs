using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using SecretHitlerMobile.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace SecretHitlerMobile.ViewModels
{
	public class LobbyPageViewModel : BindableBase
	{
		private string _lobbyIdLabelText;
		private readonly INavigationService _navigationService;

		public DelegateCommand NavigateToMainpageCommand {get; private set;}

		public string UpdateLobbyIdLabel
		{
			get => _lobbyIdLabelText;
			set => SetProperty(ref _lobbyIdLabelText, value);
		}

		public static ICollection<User> UserList { get; set; }

		public LobbyPageViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			NavigateToMainpageCommand = new DelegateCommand(async() => await NavigateToMainpageAsync());
			SetLobbyIdText("282938");
		}

		public static ICollection<User> GetUsersList()
		{
			return UserList ?? (UserList = new ObservableCollection<User>() {
					new User {
						Id = 1,
						Name = "alfred jhonas"
					},
					new User {
						Id = 2,
						Name = "bette lünasrt"
					}
			});
		}

		public void SetLobbyIdText(string id)
		{
			UpdateLobbyIdLabel =  "LobbyID: " + id;
		}

		private async Task NavigateToMainpageAsync()
		{
			var param = new NavigationParameters
			{
				{ "CanExecuteNavigation", true }
			};

			await _navigationService.GoBackAsync(param);
			
		}
	}
}