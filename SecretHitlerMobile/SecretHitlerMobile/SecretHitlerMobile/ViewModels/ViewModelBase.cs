using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace SecretHitlerMobile.ViewModels
{
	public class ViewModelBase : BindableBase, INavigationAware, IDestructible
	{
		protected INavigationService NavigationService { get; private set; }

		public ViewModelBase(INavigationService navigationService)
		{
			NavigationService = navigationService;
		}

		#region INavigationAware

		public virtual void OnNavigatedFrom(INavigationParameters parameters)
		{

		}

		public virtual void OnNavigatedTo(INavigationParameters parameters)
		{

		}

		public virtual void OnNavigatingTo(INavigationParameters parameters)
		{

		}

		#endregion

		#region IDestructible

		public virtual void Destroy()
		{

		}

		#endregion
	}
}
