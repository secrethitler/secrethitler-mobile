using Prism.Navigation;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using SecretHitlerMobile.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecretHitlerMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CreateGamePopup : PopupPage
	{
		public CreateGamePopup()
		{
			InitializeComponent();
		}

		private async void OnClose(object sender, EventArgs e)
		{
			await PopupNavigation.Instance.PopAsync();
		}
	}
}