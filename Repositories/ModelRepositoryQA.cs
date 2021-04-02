using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class ModelRepositoryQA : IModelRepository
    {
        static List<Model> models;

        public ModelRepositoryQA()
        {
            models = new List<Model>();
        }

        public void Add(AddModelVM viewmodel)
        {
            
            Model model = new Model();
            //set modelname - from html textbox
            model.ModelName = viewmodel.vehicleModel.ModelName;
            //sets new id
            model.ModelId = models.Max(m => m.ModelId) + 1;
            //sets dateadded
            model.DateAdded = DateTime.Today.ToShortDateString();
            model.MakeId = Convert.ToInt32(viewmodel.SelectedMakeId);

            List<Make> makes = MakeRepositoryQA.makes;

            var make = makes.FirstOrDefault(m => m.MakeId == model.MakeId);
            model.MakeName = make.MakeName;
            // linq query to get the emmail address of the current user
            var users = UserRepositoryQA.users;
            var currentuser = users.Where(u => u.UserName == viewmodel.currentUsername).FirstOrDefault();

            //now current user email is in the DB
            model.currentUserEmail = currentuser.Email;

            //make.currentUserEmail = repository.Users.FirstOrDefault( u => u.Email == u.UserName == make.)
            //The INSERT statement conflicted with the FOREIGN KEY constraint "FK_dbo.Makes_dbo.Users_UserId". The conflict occurred in database "CarDealership2EF", table "dbo.Users", column 'UserId'.
            //The statement has been terminated.
            //I think this is happening because I did not set userid
            //make.UserId = 1;//will change this when I know how to get the current user
            //make.User = repository.Users.First(m => m.UserId == make.UserId);

            //have to be logged in so can get current user


            models.Add(model);
          
        }

        public IEnumerable<Model> GetAll()
        {
            var m = from model in models
                    select model;

            return m;
        }
    }
}