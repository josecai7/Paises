﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Tierras.Domain;

namespace Tierras.Backend.Models
{
    [NotMapped]
    public class UserView:User
    {
        [DataType( DataType.Password )]
        [Required( ErrorMessage = "The field {0} is required" )]
        [StringLength( 20, ErrorMessage = "The length for field {0} must be betwen {1} and {2} characters", MinimumLength = 6 )]
        public string Password { get; set; }

        [DataType( DataType.Password )]
        [Required( ErrorMessage = "The field {0} is required" )]
        [Compare( "Password", ErrorMessage = "The password and confirm does not match" )]
        [Display( Name = "Password confirm" )]
        public string PasswordConfirm { get; set; }
    }
}