namespace CarDealership2.Migrations
{
    using CarDealership2.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CarDealership2.CarDealership2DbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            
        }

        protected override void Seed(CarDealership2.CarDealership2DbContext context)
        {
            //This method will be called after migrating to the latest version.

                 //You can use the DbSet<T>.AddOrUpdate() helper extension method
                 //to avoid creating duplicate seed data.
            //context.Users.AddOrUpdate(
            ////do not have access to foreign keys yet, so need to use different unique identifier
            // u => u.Email,
            // new Models.User { FirstName = "Tom", LastName = "Baker", Email = "tbaker@sgcars.com", Role = "Admin", Password = "Tardis4" },
            // new Models.User { FirstName = "William", LastName = "Hartnell", Email = "whartnell@sgcars.com", Role = "Admin", Password = "Tardis1" }
            // );
            //context.SaveChanges();

            context.Makes.AddOrUpdate(
                m => m.MakeName,
                new Models.Make
                {
                    MakeName = "Tesla",
                    DateAdded = "2/15/2021",
                    //UserId = context.Users.First(u => u.Email == "tbaker@sgcars.com").UserId
                }

                );

            context.Models.AddOrUpdate(
            m => m.ModelName,
            new Models.Model
            {
                ModelName = "A4",
                DateAdded = "1/1/2016",
                    //UserId = context.Users.First(u => u.Email == "tbaker@sgcars.com").UserId
                }

            );


            context.Models.AddOrUpdate(
            m => m.ModelName,
            new Models.Model
            {
                ModelName = "A6",
                DateAdded = "2/2/2016",
                    //UserId = context.Users.First(u => u.Email == "tbaker@sgcars.com").UserId
                }

            );

            context.SaveChanges();

            //** identity context seed method
            // Load the user and role managers with our custom models
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            // have we loaded roles already?
            if (roleMgr.RoleExists("admin"))
                return;
            
            if (roleMgr.RoleExists("sales"))
                return;

            


            // create the admin role
            roleMgr.Create(new AppRole() { Name = "admin" });
            roleMgr.Create(new AppRole() { Name = "sales" });

            // create the default user
            var user1 = new AppUser()
            {
                UserName = "admin",
                Email = "admin@sgcars.com",
                FirstName = "Tom",
                LastName ="Baker",
                RoleName ="Admin"

            };
            context.SaveChanges();



            // create the user with the manager class
            userMgr.Create(user1, "testing123");

            // add the user to the admin role
            userMgr.AddToRole(user1.Id, "admin");

            var user2 = new AppUser()
            {
                UserName = "sales",
                Email = "sales@sgcars.com",
                FirstName = "William",
                LastName = "Hartnel",
                RoleName = "Sales"
            };
            context.SaveChanges();

            // create the user with the manager class
            userMgr.Create(user2, "testing456");

            // add the user to the sales role
            userMgr.AddToRole(user1.Id, "sales");

        }
    }
}
