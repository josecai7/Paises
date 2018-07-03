using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Tierras1.Models;
using Tierras1.Services;
using Tierras1.Views;
using Xamarin.Forms;

namespace Tierras1.ViewModels
{
    public class TierrasViewModel:BaseViewModel
    {
        #region Services

        private ApiService apiService;
        #endregion

        #region Attributes
        List<Tierra> tierrasOriginal;
        private ObservableCollection<Tierra> tierrasList;
        private bool isRefreshing;
        private string filter;
        private Tierra selectedItem;
        #endregion

        #region Properties
        public ObservableCollection<Tierra> TierrasList
        {
            get
            {
                return tierrasList;
            }
            set
            {
                SetValue( ref tierrasList, value );
            }
        }
        public Tierra SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                SetValue( ref selectedItem, value );
                if ( selectedItem != null )
                {
                    ManageSelectedItem(selectedItem);
                }
            }
        }

        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                SetValue( ref isRefreshing, value );
            }
        }
        public string Filter
        {
            get
            {
                return filter;
            }
            set
            {
                SetValue( ref filter, value );
                Search();
            }
        }
        #endregion

        #region Commands
        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadLands);
            }
        }

        public ICommand SearchCommand
        {
            get
            {
                return new RelayCommand( Search );
            }
        }
        #endregion

        #region Constructors
        public TierrasViewModel()
        {
            apiService = new ApiService();






            LoadLands();
        }
        #endregion

        private async void LoadLands()
        {
            string s = MainViewModel.GetInstance().User.FirstName;
            IsRefreshing = true;
            var connection = apiService.CheckConnection().Result;
            if ( connection.IsSuccess )
            {
                Response response = await apiService.GetList<Tierra>( Application.Current.Resources["APITierras"].ToString(), "/rest", "/v2/all" );
                if ( response.IsSuccess )
                {
                    tierrasOriginal = response.Result as List<Tierra>;
                    TierrasList = new ObservableCollection<Tierra>( tierrasOriginal );
                    IsRefreshing = false;
                }
                else
                {
                    IsRefreshing = false;
                    await App.Navigator.PopAsync();
                    return;
                }
            }
            else
            {
                IsRefreshing = false;
                await App.Navigator.PopAsync();
                return;
            }

        }
        private async void ManageSelectedItem(Tierra pSelectedItem)
        {
            MainViewModel.GetInstance().Tierra = new TierraViewModel(pSelectedItem);
            await App.Navigator.PushAsync( new LandTabbedPage() );
        }
        private void Search()
        {
            if ( !string.IsNullOrEmpty( Filter ) )
            {
                TierrasList = new ObservableCollection<Tierra>( tierrasOriginal.Where( item => item.Name.ToLower().Contains( Filter.ToLower() ) || item.Capital.ToLower().Contains( Filter.ToLower() ) ) );
            }
            else
            {
                TierrasList = new ObservableCollection<Tierra>( tierrasOriginal );
            }
        }
    }
}
