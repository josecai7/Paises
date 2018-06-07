using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Tierras.Views;
using Xamarin.Forms;

namespace Tierras.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties

        public string Email
        {
            get { return email; }
            set { SetValue( ref email, value ); }
        }
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
        #endregion

        public LoginViewModel()
        {
            IsRemember = false;
            IsEnabled = true;
            Email = "jasoljim92@gmail.com";
            Password = "lugubre14";
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

            this.Email = string.Empty;
            this.Password = string.Empty;

            MainViewModel.GetInstance().Tierras = new TierrasViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new TierrasPage());
        }


    }
}
