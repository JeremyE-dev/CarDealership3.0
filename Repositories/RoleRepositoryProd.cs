using CarDealership2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class RoleRepositoryProd
    {
        public List<IdentityRole> GetAll()
        {
            var repository = new CarDealership2DbContext();

            //get the role name here and set it somehow
            //
            //var x = repository.


            var r = from role in repository.Roles
                    select role;

            //foreach(User x in repository.Users)

            return r.ToList();


        }
    }
}