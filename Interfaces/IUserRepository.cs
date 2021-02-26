using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership2.Interfaces
{
    public interface IUserRepository
    {
        void Add(AddUserVM viewmodel);
        //IEnumerable<UserData> GetAll();

        List<AppUser> GetAll();
    }
}
