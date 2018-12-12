using Anna_Baseley_Lab21.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Anna_Baseley_Lab21.Data
{
    public class UserDbContext : IdentityDbContext<User>
    {
        public UserDbContext(string connectionString) : base(connectionString) { }
    }
}