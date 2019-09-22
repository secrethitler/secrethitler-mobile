﻿using Prism;
using Prism.Ioc;
using Prism.Navigation;
using SecretHitlerMobile.ViewModels;
using SecretHitlerMobile.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SecretHitlerMobile
{
	public partial class App
	{
		/* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
		public App() : this(null) { }

		public App(IPlatformInitializer initializer) : base(initializer) { }

		protected override async void OnInitialized()
		{
			InitializeComponent();

			var p = new NavigationParameters
			{
				{ "CanExecuteNavigation", true }
			};

			await NavigationService.NavigateAsync("MainPage",p);
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LobbyPage, LobbyPageViewModel>();

        }
	}
}
