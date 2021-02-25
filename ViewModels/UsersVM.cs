using CarDealership2.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.ViewModels
{
    public class UsersVM
    {
        public RoleManager<IdentityRole> roleManager;

        public UserManager<AppUser> userManager;
       

        public string role;

        public IEnumerable <AppUser> UserList { get; set; }

        public UsersVM()
        {
            role = "";
            

        }
    }
}