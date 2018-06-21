using System;
using System.Collections.Generic;
using System.Text;
using Tierras1.ViewModels;

namespace Tierras1.Infrastructure
{

    public class InstanceLocator
    {
        #region Properties
        public MainViewModel  Main { get; set; }

        #endregion

        #region Constructors
        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
        #endregion
    }
}
