using ch_hello_world.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions; 

namespace ch_hello_world.DAL
{
    public class Users : DbContext
    {
      
        public DbSet<Name> Name { get; set;  }
    }
   
}