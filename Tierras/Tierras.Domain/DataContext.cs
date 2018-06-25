using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Tierras.Domain
{
    public class DataContext : DbContext
    {
        public DataContext():base( "DefaultConnection" )
        {
               
        }

        public System.Data.Entity.DbSet<Tierras.Domain.User> Users { get; set; }

        public System.Data.Entity.DbSet<Tierras.Domain.UserType> UserTypes { get; set; }
    }
}
