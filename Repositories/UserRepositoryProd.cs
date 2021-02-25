using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class UserRepositoryProd : IUserRepository
    {
        public IEnumerable<AppUser> UserList { get; set; }

        public void Add(AddUserDataVM viewmodel)
        {
            throw new NotImplementedException();
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