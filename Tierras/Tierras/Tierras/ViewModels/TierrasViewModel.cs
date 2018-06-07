using Lands.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tierras.Models;

namespace Tierras.ViewModels
{
    public class TierrasViewModel:BaseViewModel
    {
        #region Services

        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Tierra> tierras;
        #endregion

        #region Properties
        public ObservableCollection<Tierra> Tierras
        {
            get
            {
                return tierras;
            }
            set
            {
                SetValue( ref tierras, value );
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
            Response response=await apiService.GetList<Tierra>( "http://restcountries.eu","/rest", "/v2/all" );
            if ( response.IsSuccess )
            {
                Tierras= response.Result as ObservableCollection<Tierra>;
            }
        }
    }
}
