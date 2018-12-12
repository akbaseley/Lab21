using Anna_Baseley_Lab21.Data;
using Anna_Baseley_Lab21.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;

namespace Anna_Baseley_Lab21
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            const string connectionString = @"Data Source=.\sqlexpress;Initial Catalog=CoffeeShopDB;Integrated Security=True";

            app.CreatePerOwinContext(() => new UserDbContext(connectionString));

            app.CreatePerOwinContext<UserStore<User>>((options, context) => new UserStore<User>(context.Get<UserDbContext>()));

            app.CreatePerOwinContext<UserManager<User>>((options, context) => new UserManager<User>(context.Get<UserStore<User>>()));

            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new Microsoft.Owin.PathString("/Identity/Login"),
            });
        }
    }
}