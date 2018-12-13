using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(Anna_Baseley_Lab21.Startup))]

namespace Anna_Baseley_Lab21
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            const string connecctionString = @"Data Source=.\sqlexpress;Initial Catalog=CoffeeShopIdentityDB;Integrated Security=True;Pooling=False";
            app.CreatePerOwinContext(() => new IdentityDbContext(connecctionString));

            app.CreatePerOwinContext<UserManager<IdentityUser>>((options, context) 
                => new UserManager<IdentityUser>(
                    new UserStore<IdentityUser>(context.Get<IdentityDbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new Microsoft.Owin.PathString("/Identity/Login"),
            });
        }
    }
}
