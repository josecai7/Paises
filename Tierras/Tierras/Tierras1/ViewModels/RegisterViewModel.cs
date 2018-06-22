using GalaSoft.MvvmLight.Command;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Tierras1.Helpers;
using Tierras1.Models;
using Tierras1.Services;
using Xamarin.Forms;

namespace Tierras1.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        public RegisterViewModel()
        {
            apiService = new ApiService();
        }

        # region Attributes

        ApiService apiService;

        private string name;
        private string surname;
        private string email;
        private string phone;
        private string password;
        private ImageSource imagesource;
        private MediaFile file;

        #endregion
        #region Properties

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                SetValue( ref name, value );
            }
        }
        public string Surname
        {
            get
            {
                return surname;
            }
            set
            {
                SetValue( ref surname, value );
            }
        }
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                SetValue( ref email, value );
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                SetValue( ref phone, value );
            }
        }
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                SetValue( ref password, value );
            }
        }
        public ImageSource ImageSource
        {
            get
            {
                return imagesource;
            }
            set
            {
                SetValue( ref imagesource, value );
            }
        }

        #endregion
        #region Commands

        public ICommand TakePhotoCommand
        {
            get
            {
                return new RelayCommand( TakePhoto );
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(Register);
            }
        }

        #endregion

        #region Methods
        public async void Register ()
        {
            byte[] imageArray = null;

            if ( file != null )
            {
                imageArray = FilesHelper.ReadFully(file.GetStream());
            }

            User user = new User();
            user.FirstName = Name;
            user.LastName = Surname;
            user.Email = Email;
            user.Telephone = Phone;
            user.ImageArray = imageArray;
            user.UserTypeId = 1;
            user.Password = Password;

            var response = await apiService.Post( 
                Application.Current.Resources["APISecurity"].ToString(),
                "/api",
                "/Users",
                user);

        }
        public async void TakePhoto()
        {
            await CrossMedia.Current.Initialize();

            if ( !CrossMedia.Current.IsCameraAvailable && !CrossMedia.Current.IsPickPhotoSupported )
            {
                return;
            }

            var source = await Application.Current.MainPage.DisplayActionSheet(
                "Elije",
                "Cancelar",
                null,
                "Desde galeria",
                "Desde camara"
                );

            if ( source == "Desde camara" )
            {
                file = await CrossMedia.Current.TakePhotoAsync(
                    new StoreCameraMediaOptions
                    {
                        Directory = "Sample",
                        Name = "test.jpg",
                        PhotoSize = PhotoSize.Full
                    }
                    );
            }

            if ( file != null )
            {
                ImageSource = ImageSource.FromStream(()=>file.GetStream());
            }
        }
        #endregion
    }
}
