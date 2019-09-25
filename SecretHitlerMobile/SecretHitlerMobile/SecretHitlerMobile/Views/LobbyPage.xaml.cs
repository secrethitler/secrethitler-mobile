using Prism.Navigation;
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
    public partial class LobbyPage : ContentPage, INavigatedAware
    {
		public LobbyPage()
        {
            InitializeComponent();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			UserListView.ItemsSource = LobbyPageViewModel.GetUserList();
		}

		/// <summary>
		/// Called when the implementer has been navigated away from.
		/// </summary>
		/// <param name="parameters">The navigation parameters.</param>
		public void OnNavigatedFrom(INavigationParameters parameters)
		{
			parameters.Add("CanExecuteNavigation", true);
		}

		/// <summary>
		/// Called when the implementer has been navigated to.
		/// </summary>
		/// <param name="parameters">The navigation parameters.</param>
		public void OnNavigatedTo(INavigationParameters parameters)
		{
		}
	}
}