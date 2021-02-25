using CarDealership2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security.Cookies;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.App_Start
{
    public class IdentityConfig
    {
        //configuration method that owin services will call when the website starts
        public void Configuration(IAppBuilder app)
        {
            //let owin know  which classes we should be using for data storage and retreival
            app.CreatePerOwinContext(() => new CarDealership2DbContext());

            app.CreatePerOwinContext<UserManager<AppUser>>((options, context) =>
                new UserManager<AppUser>(
                    //Error: There is no argument given that corresponds to the
                    //required formal parameter of key IOwinContext.Get<T>(string) - resolved by  added using statement
                    //using Microsoft.AspNet.Identity.Owin;
                    new UserStore<AppUser>(context.Get<CarDealership2DbContext>())));

            app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) =>
                new RoleManager<AppRole>(
                    new RoleStore<AppRole>(context.Get<CarDealership2DbContext>())));
            //experiment
            //app.CreatePerOwinContext<UserManager<AppUser>>((options, context) =>
            //    new UserManager<AppUser>(
            //        new UserStore<AppUser>(context.Get<CarDealership2DbContext>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new Microsoft.Owin.PathString("/Home/Login"),
            });

        }
    }
}