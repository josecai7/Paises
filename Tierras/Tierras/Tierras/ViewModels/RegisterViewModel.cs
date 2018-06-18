using System;
using System.Collections.Generic;
using System.Text;

namespace Tierras.ViewModels
{
    public class RegisterViewModel:BaseViewModel
    {
        # region Attributes

        private string name;

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

        #endregion
    }
}
