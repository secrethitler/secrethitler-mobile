using Prism.Commands;
using Prism.Mvvm;
using SecretHitlerMobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace SecretHitlerMobile.ViewModels
{
    public class LobbyPageViewModel : BindableBase
    {
		public string UpdateLobbyIdLabel {
			get { return _lobbyIdLabelText; }
			set { SetProperty(ref _lobbyIdLabelText, value); }
		}

		public static IList<User> UserList { get; set; }

		private string _lobbyIdLabelText;

		public LobbyPageViewModel()
		{
			SetLobbyIdText();
		}

		public static IList<User> GetUsersList()
		{
			UserList = new ObservableCollection<User>() {
					new User {
						Name = "alfred jhonas"
					},
					new User {
						Name = "bette lünasrt"
					}
				};

			return UserList;
		}

		public void SetLobbyIdText(string id = "LobbyID: 282938"){
			UpdateLobbyIdLabel = id;
		}
	}
}