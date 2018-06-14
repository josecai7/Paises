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
    }
}
