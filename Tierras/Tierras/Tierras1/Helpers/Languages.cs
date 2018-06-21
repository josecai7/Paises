using System;
using System.Collections.Generic;
using System.Text;
using Tierras1.Interfaces;
using Tierras1.Resources;
using Xamarin.Forms;

namespace Tierras1.Helpers
{
    public static class Languages
    {
        static Languages()
        {
            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            Resource.Culture = ci;
            DependencyService.Get<ILocalize>().SetLocale( ci );
        }
            public static string Error
            {
                get
                {
                    return Resource.Error;
                }
            }
            public static string EmailValidation
            {
                get
                {
                    return Resource.EmailValidation;
                }
            }
            public static string PassValidation
            {
                get
                {
                    return Resource.PassValidation;
                }
            }
            public static string Accept
            {
                get
                {
                    return Resource.Accept;
                }
            }
        public static string Password
        {
            get
            {
                return Resource.Password;
            }
        }

    }
}

