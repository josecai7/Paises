using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tierras.Domain;

namespace Tierras.API.Models
{
    public class UserRequest:User
    {
        public  string Password { get; set; }
        public byte[] ImageArray { get; set; }

        public User ToUser()
        {
            return new User {
                UserId = this.UserId,
                Email = this.Email,
                FirstName = this.FirstName,
                LastName = this.LastName,
                UserType = this.UserType,
                UserTypeId = this.UserTypeId,
                Telephone = this.Telephone,
                ImagePath = this.ImagePath,
            };
        }
    }
}