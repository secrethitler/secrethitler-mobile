using SecretHitlerMobile.Models;
using SecretHitlerMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecretHitlerMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LobbyPage : ContentPage
    {
		public LobbyPage()
        {
            InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			UserListView.ItemsSource = LobbyPageViewModel.GetUsersList();
		}
	}
}