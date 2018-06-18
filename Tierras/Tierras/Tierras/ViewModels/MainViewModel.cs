using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tierras.Models;

namespace Tierras.ViewModels
{
    public class MainViewModel
    {
        #region Properties

        public string Token { get; set; }

        public string TokenType { get; set; }

        public ObservableCollection<MenuItemViewModel> MenuItems { get; set; }
        #endregion

        #region ViewModels

        public LoginViewModel Login { get; set; }
        public RegisterViewModel Register { get; set; }
        public TierrasViewModel Tierras { get; set; }
        public TierraViewModel Tierra { get; set; }

        #endregion

        #region Contructors

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();

            LoadMenu();
        }
        #endregion

        #region Methods

        private void LoadMenu()
        {
            MenuItems = new ObservableCollection<MenuItemViewModel>();

            MenuItems.Add( new MenuItemViewModel { Icon = "icon.png", Title = "Mi perfil",PageName="" } );

            MenuItems.Add( new MenuItemViewModel { Icon = "TierrasLogo.png", Title = "Tierras", PageName = "LandTabbedPage" } );

            MenuItems.Add( new MenuItemViewModel { Icon = "icon.png", Title = "Cerrar sesion", PageName = "LoginPage" } );


        }

        #endregion

        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if ( instance == null )
                return new MainViewModel();
            else
                return instance;
        }
        #endregion
    }
}
