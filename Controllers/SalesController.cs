﻿using CarDealership2.Factories;
using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace CarDealership2.Controllers
{
    public class SalesController : Controller
    {
        // GET: Sales
        [HttpGet]
        public ActionResult SalesIndex()
        {
            //Search all vehicles
            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();
            List<Vehicle> VehicleList = new List<Vehicle>();

            VehicleList = vehicleRepository.GetAllUnSoldVehicles().ToList();

            return View(VehicleList);
            
        }

        [Route("GetIndexSearchResults/{searchTerm}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        //[Route("GetVehicleSearchResults/{searchTerm}/{}")]
        [HttpGet]
        public ActionResult GetSalesIndexSearchResults(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {


            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();
            List<Vehicle> VehicleRepoList = new List<Vehicle>();

            //if all fields are empty return all of the vehicles

            if (searchTerm == "0" && minPrice == 0 && maxPrice == 0 && minYear == 0 && maxYear == 0)
            {
                VehicleRepoList = vehicleRepository.GetAllUnSoldVehicles().ToList();
            }

            else
            {
                VehicleRepoList = vehicleRepository.SearchUnSoldVehicles(searchTerm, minPrice, maxPrice, minYear, maxYear).ToList();
            }

            ViewBag.List = VehicleRepoList; // could I loop through this 


            return Json(VehicleRepoList, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Purchase(int id)
        {
            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();


            var model = new PurchaseVM();
            model.vehicle = vehicleRepository.GetVehicleById(id);


            //lets see if this works with a list of strings
            //model.States = from s in model._states
            //                  select new SelectListItem { Text = s, Value = "foo"};

            //get identity of user
            model.salesPerson = new AppUser();
            model.salesPerson.Id = User.Identity.GetUserId();
           
            return View(model);
        }

        [HttpPost] // add int id
        public ActionResult Purchase(PurchaseVM model, int id)
        {
            IPurchaseRepository purchaseRepo = PurchaseRepositoryFactory.Create();
            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();
            model.vehicle = vehicleRepository.GetVehicleById(id);


            //model.vehicle.IsPurchased = true;
            //model.purchaseDate = DateTime.Today;



            purchaseRepo.Add(model);


            return View("Index");
        }


    }
}