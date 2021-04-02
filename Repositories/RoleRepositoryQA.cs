using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class RoleRepositoryQA : IRoleRepository
    {
        public static List<LocalRole> roles;

        public RoleRepositoryQA()
        {
            LocalRole admin = new LocalRole {RoleId = "1", RoleName= "admin" };
            LocalRole sales = new LocalRole { RoleId = "2", RoleName = "sales" };

            roles = new List<LocalRole>();
            roles.Add(admin);
            roles.Add(sales);

        }

        public IEnumerable<LocalRole> GetAll()
        {
            var r = from role in roles
                    select role;

            return r;
        }
    }
}