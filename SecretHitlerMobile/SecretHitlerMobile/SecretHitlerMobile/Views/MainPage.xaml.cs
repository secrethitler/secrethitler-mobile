using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SecretHitlerMobile.Views
{
	public partial class MainPage : ContentPage
	{

		public MainPage()
		{
			InitializeComponent();
		}

		//Opens the Dialog for Joining a Game
		private async void OnUsernameDialogOpenAsync(object sender, EventArgs e)
		{
			var usernameDialogPopup = new UsernameDialog();
			await PopupNavigation.Instance.PushAsync(usernameDialogPopup);
		}
	}
}