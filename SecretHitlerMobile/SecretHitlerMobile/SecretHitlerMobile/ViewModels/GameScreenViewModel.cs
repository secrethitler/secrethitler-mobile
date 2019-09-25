using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecretHitlerMobile.ViewModels
{
	//Primary GameScreen ViewModel
	public class GameScreenViewModel : BindableBase
	{
		private readonly INavigationService _navigationService;

		#region Commands
		public DelegateCommand NavigateBackToLobby { get; set; }
		#endregion

		public GameScreenViewModel(INavigationService navigationService)
		{
			_navigationService = navigationService;
			NavigateBackToLobby = new DelegateCommand(async () => await NavigateToLobbyAsync());
		}

		#region Methods

		private async Task NavigateToLobbyAsync()
		{
			var param = new NavigationParameters{
				{ "CanExecuteNavigationGameScreen", true }
			};
			await _navigationService.GoBackAsync(param);
		}

		#endregion
	}
}
