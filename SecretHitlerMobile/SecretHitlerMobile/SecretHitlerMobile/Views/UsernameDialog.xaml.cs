﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SecretHitlerMobile.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class UsernameDialog : PopupPage
	{
		public UsernameDialog()
		{
			InitializeComponent();
		}

		private async void OnClose(object sender, EventArgs e)
		{
			await PopupNavigation.Instance.PopAsync();
		}

		private void LoginButton_Clicked(object sender, EventArgs e)
		{

		}
	}
}