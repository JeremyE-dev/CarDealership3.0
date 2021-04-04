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
        public static List<Model> models { get; set;}

        public ModelRepositoryQA()
        {
            models = new List<Model>();

            
            Model model1 = new Model
            {
                ModelName = "A1",
                ModelId = 1,
                DateAdded = DateTime.Today.ToShortDateString(),
                MakeId = 1,
                MakeName = "Audi",
                currentUserEmail = "jeudaly@sgcars.com"
            };

            Model model2 = new Model
            {
                ModelName = "B1",
                ModelId = 2,
                DateAdded = DateTime.Today.ToShortDateString(),
                MakeId = 2,
                MakeName = "Buick",
                currentUserEmail = "jeudaly@sgcars.com"
            };

            Model model3 = new Model
            {
                ModelName = "C1",
                ModelId = 3,
                DateAdded = DateTime.Today.ToShortDateString(),
                MakeId = 3,
                MakeName = "Cadillac",
                currentUserEmail = "jeudaly@sgcars.com"
            };

            Model model4 = new Model
            {
                ModelName = "D1",
                ModelId = 4,
                DateAdded = DateTime.Today.ToShortDateString(),
                MakeId = 4,
                MakeName = "Dodge",
                currentUserEmail = "jeudaly@sgcars.com"
            };


            Model model5 = new Model
            {
                ModelName = "F1",
                ModelId = 5,
                DateAdded = DateTime.Today.ToShortDateString(),
                MakeId = 5,
                MakeName = "Fiat",
                currentUserEmail = "jeudaly@sgcars.com"
            };

            models.Add(model1);
            models.Add(model2);
            models.Add(model3);
            models.Add(model4);
            models.Add(model5);


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

            MakeRepositoryQA MakeRepo = new MakeRepositoryQA();



            List<Make> makes = MakeRepo.GetAll().ToList();

            var make = makes.FirstOrDefault(m => m.MakeId == model.MakeId);
            model.MakeName = make.MakeName;
            // linq query to get the emmail address of the current user

            UserRepositoryQA UserRepo = new UserRepositoryQA();

            List<UserData> users = UserRepo.TestGetAll().ToList();
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