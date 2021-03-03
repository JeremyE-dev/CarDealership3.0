using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class UserRepositoryQA : IUserRepository
    {
   

        public void Add(AddUserVM viewmodel)
        {
            throw new NotImplementedException();
        }

        public void Edit(EditUserVM viewmodel)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<UserData> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        List<AppUser> IUserRepository.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}