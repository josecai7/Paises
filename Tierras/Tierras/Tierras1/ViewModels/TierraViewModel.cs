using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Tierras1.Models;

namespace Tierras1.ViewModels
{
    public class TierraViewModel:BaseViewModel
    {
        #region Attributes
        private Tierra tierra;
        private ObservableCollection<Currency> currencies;
        #endregion
        #region Properties
        public Tierra Tierra
        {
            get
            {
                return tierra;
            }
            set
            {
                SetValue(ref tierra, value );
            }
        }
        public ObservableCollection<Currency> Currencies
        {
            get
            {
                return currencies;
            }
            set
            {
                SetValue( ref currencies, value );
            }
        }
        #endregion
        public TierraViewModel(Tierra pSelectedItem)
        {
            tierra = pSelectedItem;
            Currencies = new ObservableCollection<Currency>(pSelectedItem.Currencies);
        }
    }
}
