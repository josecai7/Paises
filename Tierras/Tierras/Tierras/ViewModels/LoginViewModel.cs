using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;

namespace Tierras.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {

        #region Attributes
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties

        public string Email { get; set; }
        public string Password
        {
            get { return password; }
            set { SetValue( ref password, value ); }
        }
        public bool IsRunning
        {
            get { return isRunning; }
            set { SetValue( ref isRunning, value ); }
        }
        public bool IsRemember { get; set; }
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetValue( ref isEnabled, value ); }
        }

        #endregion

        #region Commands

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        public LoginViewModel()
        {
            IsRemember = false;
            IsEnabled = true;
        }

        private async void Login()
        {
            if ( string.IsNullOrEmpty( this.Email ) )
            {
                await Application.Current.MainPage.DisplayAlert("Error","Introduce el Email","Aceptar");
                return;
            }
            if ( string.IsNullOrEmpty( this.Password ) )
            {
                await Application.Current.MainPage.DisplayAlert( "Error", "Introduce la contraseña", "Aceptar" );
                return;
            }

            this.isRunning = true;
            this.IsEnabled = false;


            if ( Password != "lugubre14" || Email != "jasoljim92@gmail.com" )
            {
                Password = "";
                await Application.Current.MainPage.DisplayAlert( "Error", "Login incorrecto", "Aceptar" );
                return;
            }

            this.isRunning = false;
            this.IsEnabled = true;
            await Application.Current.MainPage.DisplayAlert( "OK", "VAMOSSSS", "Aceptar" );
        }

        #endregion


    }
}
