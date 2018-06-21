using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tierras1.Helpers;
using Tierras1.ViewModels;
using Tierras1.Views;
using Xamarin.Forms;

namespace Tierras1
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
                MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                MainViewModel.GetInstance().Token = Settings.Token;
                MainViewModel.GetInstance().TokenType = Settings.TokenType;

                MainViewModel.GetInstance().Tierras1 = new TierrasViewModel();
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
