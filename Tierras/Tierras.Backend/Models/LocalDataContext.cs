using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tierras.Domain;

namespace Tierras.Backend.Models
{
    public class LocalDataContext: DataContext
    {
        public System.Data.Entity.DbSet<Tierras.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<Tierras.Domain.UserType> UserTypes { get; set; }
    }
}