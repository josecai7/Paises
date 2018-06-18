using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Tierras.Helpers;
using Tierras.Resources;
using Tierras.Services;
using Tierras.Views;
using Xamarin.Forms;

namespace Tierras.ViewModels
{
    public class LoginViewModel: BaseViewModel
    {
        #region Services

        private ApiService apiService;

        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isRemember;
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
        public bool IsRemember
        {
            get { return isRemember; }
            set { SetValue( ref isRemember, value ); }
        }
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
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand( Register );
            }
        }
        #endregion

        public LoginViewModel()
        {
            IsRemember = false;
            IsEnabled = true;
            apiService = new ApiService();
        }

        private async void Login()
        {
            

            if ( string.IsNullOrEmpty( this.Email ) )
            {
                await Application.Current.MainPage.DisplayAlert(Languages.Error, Languages.EmailValidation, Languages.Accept);
                return;
            }
            if ( string.IsNullOrEmpty( this.Password ) )
            {
                await Application.Current.MainPage.DisplayAlert( Languages.Error, Languages.PassValidation, Languages.Accept );
                return;
            }

            IsRunning = true;
            this.IsEnabled = false;

            var connection = apiService.CheckConnection();
            if ( !connection.Result.IsSuccess )
            {
                IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert( "Error", "Revise su conexion a internet", "Aceptar" );
                return;
            }

            var token = await apiService.GetToken( "http://tierrasapi.azurewebsites.net", Email,Password);

            if ( token == null )
            {
                IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert( "Error", "Algo fue mal...intentalo de nuevo mas tarde", "Aceptar" );
                return;
            }
            else if ( string.IsNullOrEmpty( token.AccessToken ) )
            {
                IsRunning = false;
                this.IsEnabled = true;
                Password = string.Empty;
                await Application.Current.MainPage.DisplayAlert( "Error",token.ErrorDescription , "Aceptar" );
                return;
            }
            else
            {
                MainViewModel.GetInstance().Token = token.AccessToken;
                MainViewModel.GetInstance().TokenType = token.TokenType;
                if ( IsRemember )
                {
                    Settings.Token = token.AccessToken;
                    Settings.TokenType = token.TokenType;
                }
            }

            IsRunning = false;
            this.IsEnabled = true;


            MainViewModel.GetInstance().Tierras = new TierrasViewModel();
            Application.Current.MainPage=new MasterPage();
        }
        private async void Register()
        {
            MainViewModel.GetInstance().Register = new RegisterViewModel();
            await Application.Current.MainPage.Navigation.PushAsync( new RegisterPage() );
        }


    }
}
