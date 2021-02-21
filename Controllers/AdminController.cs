﻿using CarDealership2.Factories;
using CarDealership2.Interfaces;
using CarDealership2.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership2.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        //Note: in memory repo, add one vehicle, static list not allowing to add multiple items
        //fix later if required

        [HttpGet]
        public ActionResult Makes()
        {
            //this should list the makes that exist
            var model = new AddMakeVM();
            //add list to model
            //get email address
            model.makes = MakeRepositoryFactory.Create().GetAll().ToList();
            //pass user name to the model and

            //model.currentUsername = User.Identity.GetUserName();
            

            //give the view a list of makes to display
            return View(model);
        }


        [HttpPost]
        public ActionResult Makes(AddMakeVM model)
        {
            //here model has currect list
            //create new instance of make repository
            //this needs to 
            IMakeRepository MakeRepo = MakeRepositoryFactory.Create();



            // model.makes = MakeRepositoryFactory.Create().GetAll().ToList();

            if (string.IsNullOrEmpty(model.make.MakeName))
            {

                ModelState.AddModelError("make.MakeName", "Please Enter a Make Name");
                //return RedirectToAction("Makes");
                //model.makes = MakeRepository.GetAll().ToList();

                //
            }
            //note: success writing to db, not displaying view only displaying after second save
            // set breakpoints: either controller iss or view

            if (ModelState.IsValid)
            {
                //add to list
                //model.Add(model.make.MakeName);
                //update list
                model.makes = MakeRepo.GetAll().ToList();
                
                model.currentUsername = User.Identity.GetUserName();

                MakeRepositoryFactory.Create().Add(model.make.MakeName, model.currentUsername);
                //add method will add the MakeName, Make Id, Date Added
                //user will be added later - when I build that 
                //return View("Makes", model);
                return RedirectToAction("Makes", model);
            }

            else
            {
                //var makeList = MakeRepository.GetAll().ToList();
                //return View("Makes");
                //model.makes = MakeRepositoryFactory.Create().GetAll().ToList();
                model.makes = MakeRepo.GetAll().ToList();
                return View("Makes", model);
            }
        }


        [HttpGet]
        public ActionResult Models()
        {
            //creates addvmmodel
            var model = new AddModelVM();
            //new instance of repo
            //needed to populated model list
            var modelRepository = ModelRepositoryFactory.Create();

            var makeRepository = MakeRepositoryFactory.Create();
            
            //populates list of models
            model.models = modelRepository.GetAll().ToList(); //this could be null - no seed data
            
            //populates drop down - I think :)
            model.Makes = from m in makeRepository.GetAll()
                          select new SelectListItem { Text = m.MakeName, Value = m.MakeId.ToString() };

            return View(model);
        }

        [HttpPost]
        public ActionResult Models(AddModelVM model)
        {
            IModelRepository ModelRepo = ModelRepositoryFactory.Create();

            var makeRepository = MakeRepositoryFactory.Create();

            var repository = ModelRepositoryFactory.Create();

            if (string.IsNullOrEmpty(model.model.ModelName))
            {

                ModelState.AddModelError("model.ModelName", "Please Enter a Model Name");

            }

            if (ModelState.IsValid)
            {

                model.models = ModelRepo.GetAll().ToList();

                model.currentUsername = User.Identity.GetUserName();

                ModelRepositoryFactory.Create().Add(model.model.ModelName, model.currentUsername);

                return RedirectToAction("Models", model);
            }

            else
            {

                model.models = ModelRepo.GetAll().ToList();
                model.Makes = from m in makeRepository.GetAll()
                              select new SelectListItem { Text = m.MakeName, Value = m.MakeId.ToString() };

                return View("Models", model);
            }

        }


    }
}