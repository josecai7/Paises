﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tierras.Helpers;
using Tierras.ViewModels;
using Tierras.Views;
using Xamarin.Forms;

namespace Tierras
{
	public partial class App : Application
	{
        #region Properties

        public static NavigationPage Navigator { get; internal set; }

        #endregion
        public App ()
		{
			InitializeComponent();

            if ( string.IsNullOrEmpty( Settings.Token ) )
            {
                MainPage = new LoginPage();
            }
            else
            {
                MainViewModel.GetInstance().Token = Settings.Token;
                MainViewModel.GetInstance().TokenType = Settings.TokenType;

                MainViewModel.GetInstance().Tierras = new TierrasViewModel();
                MainPage = new MasterPage();
            }

		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
