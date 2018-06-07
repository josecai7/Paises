﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Tierras.ViewModels
{
    public class MainViewModel
    {
        #region ViewModels

        public LoginViewModel Login { get; set; }
        public TierrasViewModel Tierras { get; set; }

        #endregion

        #region Contructors

        public MainViewModel()
        {
            instance = this;
            this.Login = new LoginViewModel();
        }
        #endregion
        #region Singleton
        private static MainViewModel instance;
        public static MainViewModel GetInstance()
        {
            if ( instance == null )
                return new MainViewModel();
            else
                return instance;
        }
        #endregion
    }
}
