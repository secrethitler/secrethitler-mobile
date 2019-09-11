using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

		private async void OnUsernameDialogOpenAsync(object sender, EventArgs e)
		{
			var UsernameDialogPopup = new UsernameDialog();

			await PopupNavigation.Instance.PushAsync(UsernameDialogPopup);
		}
	}
}