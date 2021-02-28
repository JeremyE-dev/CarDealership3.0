using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace CarDealership2.Repositories
{
    public class UserRepositoryProd : IUserRepository
    {


        public UserManager<AppUser> userManager;

        public IEnumerable<AppUser> UserList { get; set; }

        //public void Add(AppUser user)
        //{
        //    var repository = new CarDealership2DbContext();

        //    repository.Users.Add(user);

        //}

        public void Add(AddUserVM viewmodel)
        {
            var repository = new CarDealership2DbContext();
            var userManager = new UserManager<AppUser>(new UserStore<AppUser>(repository));
       
            var user = new AppUser
            {
                FirstName = viewmodel.FirstName,
                LastName = viewmodel.LastName,
                Email = viewmodel.Email,
                UserName = viewmodel.Email,
                RoleName = viewmodel.SelectedRoleType.ToString()
                                
            };
            
            userManager.Create(user, viewmodel.Password);
            userManager.AddToRole(user.Id, viewmodel.SelectedRoleType.ToString());

           
            //SAVED FOR LATER
            //userManager.AddPassword(user.Id, viewmodel.Password);

        }

        public List<AppUser> GetAll()
        {
            var repository = new CarDealership2DbContext();

            //get the role name here and set it somehow
            //
            //var x = repository.


            var u = from user in repository.Users
                    select user;

            //foreach(User x in repository.Users)



            return u.ToList();

            
        }

      
    }
}