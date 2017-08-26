using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ch_hello_world.Models;

namespace ch_hello_world.DAL
{
    public class UsersInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<Users>
    {
        protected override void Seed(Users context)
        {
            var names = new List<Name>
            {           
                new Name{firstName = "Martha", lastName="Kent"},
                new Name{firstName = "Bruce", lastName="Wayne"},
                new Name{firstName = "Barry", lastName="Allen"},
                new Name{firstName = "Wally", lastName="West"},
                new Name{firstName = "Clark", lastName="Kent"},
                new Name{firstName = "Kara", lastName="Kent"},
                new Name{firstName = "Oliver", lastName="Queen"},
                new Name{firstName = "Speedy", lastName="Queen"},
                new Name{firstName = "Hal", lastName="Jordan"},
                new Name{firstName = "Tony", lastName="Stark"},
                new Name{firstName = "Peter", lastName="Parker"},
                new Name{firstName = "Speedy", lastName="Queen"},
                new Name{firstName = "Matt", lastName="Murdock"},
                new Name{firstName = "Steve", lastName="Rogers"},
                new Name{firstName = "Bruce", lastName="Banner"},
                new Name{firstName = "Martin", lastName="Stein"},
                new Name{firstName = "Ronald", lastName="Raymond"},
                new Name{firstName = "Speedy", lastName="Queen"},
                new Name{firstName = "Ray", lastName="Palmer"}

            };

            names.ForEach(s => context.Name.Add(s));
            context.SaveChanges();
        }
    }
}