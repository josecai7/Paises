using GalaSoft.MvvmLight.Command;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Tierras1.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        # region Attributes

        private string name;
        private string surname;
        private string email;
        private string phone;
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
                name = value;
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
                surname = value;
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
                email = value;
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
                phone = value;
                SetValue( ref phone, value );
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
        public void Register ()
        {

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
