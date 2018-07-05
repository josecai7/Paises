using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tierras1.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Telephone { get; set; }

        public int UserTypeId { get; set; }

        public string Password { get; set; }
        public byte[] ImageArray { get; set; }
        public string ImagePath { get; set; }
        public string ImageFullPath
        {
            get
            {
                if ( string.IsNullOrEmpty( ImagePath ) )
                {
                    return "noimage";
                }
                return string.Format(
                    Application.Current.Resources["APISecurity"].ToString() +"/{0}",
                    ImagePath.Substring( 1 ) );
            }
        }
    }
}
