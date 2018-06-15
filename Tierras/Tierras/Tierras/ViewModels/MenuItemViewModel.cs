using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tierras.Helpers;
using Tierras.Views;
using Xamarin.Forms;

namespace Tierras.ViewModels
{
    public class MenuItemViewModel
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string PageName { get; set; }

        #region Commands
        public ICommand NavigateCommand {
            get
            {
                return new RelayCommand( Navigate );
            }
        }

        private void Navigate()
        {
            if ( this.PageName == "LoginPage" )
            {
                Settings.Token = String.Empty;
                Settings.TokenType = String.Empty;
                MainViewModel.GetInstance().Token = String.Empty;
                MainViewModel.GetInstance().TokenType = String.Empty;
                Application.Current.MainPage = new LoginPage();
            }
            else if ( this.PageName == "" )
            {

            }
            else if ( this.PageName == "" )
            {

            }

        }
        #endregion
    }
}
