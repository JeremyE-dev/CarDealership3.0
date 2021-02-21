using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class ModelRepositoryProd : IModelRepository
    {
        public void Add(string modelname, string username)
        {
            var repository = new CarDealership2DbContext();
            Model model = new Model();
            model.ModelName = modelname;
            model.ModelId = repository.Models.Max(m => m.ModelId) + 1;
            model.DateAdded = DateTime.Today.ToShortDateString();
            //model.MakeId = model.SelectedMakeId;
            //var Make = repository.Makes.FirstOrDefault(m => m.MakeId == model.MakeId);
            //model.MakeName = Make.MakeName;
            // linq query to get the emmail address of the current user
            var currentuser = repository.Users.Where(u => u.UserName == username).FirstOrDefault();

            //now current user email is in the DB
            model.currentUserEmail = currentuser.Email;

            //make.currentUserEmail = repository.Users.FirstOrDefault( u => u.Email == u.UserName == make.)
            //The INSERT statement conflicted with the FOREIGN KEY constraint "FK_dbo.Makes_dbo.Users_UserId". The conflict occurred in database "CarDealership2EF", table "dbo.Users", column 'UserId'.
            //The statement has been terminated.
            //I think this is happening because I did not set userid
            //make.UserId = 1;//will change this when I know how to get the current user
            //make.User = repository.Users.First(m => m.UserId == make.UserId);

            //have to be logged in so can get current user


            repository.Models.Add(model);
            repository.SaveChanges();
        }

        public IEnumerable<Model> GetAll()
        {
            var repository = new CarDealership2DbContext(); //this repo has access to everything in the context

            var m = from model in repository.Models
                    select model;

            return m;
        }
    }
}