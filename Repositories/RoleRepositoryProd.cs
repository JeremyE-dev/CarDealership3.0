using CarDealership2.Interfaces;
using CarDealership2.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class RoleRepositoryProd : IRoleRepository
    {
        //public List<IdentityRole> GetAll()
        public IEnumerable<LocalRole> GetAll()
        {
            var repository = new CarDealership2DbContext();

            List<LocalRole> LocalRoleList = new List<LocalRole>();

            //get the role name here and set it somehow
            //
            //var x = repository.


            var r = from role in repository.Roles
                    select role;

            foreach(AppRole x in r)
            {
                LocalRole lr = new LocalRole();

                lr.RoleId = x.Id;
                lr.RoleName = x.Name;

                LocalRoleList.Add(lr);
            }



            //foreach(User x in repository.Users)

            //return r.ToList();

            return LocalRoleList;


        }
    }
}