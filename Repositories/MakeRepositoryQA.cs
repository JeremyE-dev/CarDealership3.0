using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class MakeRepositoryQA : IMakeRepository
    {
        public static List<Make> makes { get; set; }

     

        public MakeRepositoryQA()
        {
            Make Audi = new Make { MakeId = 1, MakeName = "Audi" };
            Make Buick = new Make { MakeId = 2, MakeName = "Buick" };
            Make Cadillac = new Make { MakeId = 3, MakeName = "Cadillac" };
            Make Dodge = new Make { MakeId = 4, MakeName = "Dodge" };
            Make Fiat = new Make { MakeId = 4, MakeName = "Fiat" };
        }
       
        public void Add(string makename, string username)
        {
            //var repository = new CarDealership2DbContext();
            List<UserData> users = UserRepositoryQA.users;

            Make make = new Make();
            make.MakeName = makename;
            make.MakeId = makes.Max(m => m.MakeId) + 1;
            make.DateAdded = DateTime.Today.ToShortDateString();

            //add users list to mock repo
            // linq query to get the emmail address of the current user
            var currentuser = users.Where(u => u.UserName == username).FirstOrDefault();

            //now current user email is in the DB
            make.currentUserEmail = currentuser.Email;

            makes.Add(make);
            //repository.SaveChanges();
        }

        public IEnumerable<Make> GetAll()
        {
            var m = from make in makes
                    select make;

            return m;
        }
    }
}