using CarDealership2.Factories;
using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using CarDealership2.Helpers;

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

            Helper helper = new Helper();


            //lets see if this works with a list of strings
            //model.States = from s in model._states
            //                  select new SelectListItem { Text = s, Value = "foo"};

            //get identity of user
            model.salesPerson = new AppUser();
            model.salesPerson.Id = User.Identity.GetUserId();

            model.username = User.Identity.GetUserName();
            string userid = User.Identity.GetUserId();
            //model.salesPerson.UserName = User.Identity.GetUserName();

            return View(model);
        }

        [HttpPost] // add int id
        public ActionResult Purchase(PurchaseVM model, int id)
        {
            IPurchaseRepository purchaseRepo = PurchaseRepositoryFactory.Create();
            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();
            model.vehicle = vehicleRepository.GetVehicleById(id);

            Helper helper = new Helper();

            model.username = User.Identity.GetUserName();
            //model.vehicle.IsPurchased = true;
            //model.purchaseDate = DateTime.Today;

            if (string.IsNullOrEmpty(model.name))
            {
                ModelState.AddModelError("name","Name Is Required");
            }

            if (string.IsNullOrEmpty(model.phone))
            {
                ModelState.AddModelError("phone", "Phone Is Required");
            }

            if (string.IsNullOrEmpty(model.email))
            {
                ModelState.AddModelError("email", "Email Is Required");
            }

            if (string.IsNullOrEmpty(model.street1))
            {
                ModelState.AddModelError("street1", "Street 1 Is Required");
            }

            if (string.IsNullOrEmpty(model.city))
            {
                ModelState.AddModelError("city", "City Is Required");
            }

            string state = model.purchaseState.ToString();

            if (string.IsNullOrEmpty(state))
            {
                ModelState.AddModelError("purchaseState", "State Is Required");
            }

            string zipcode = model.zipcode.ToString();

            if (string.IsNullOrEmpty(zipcode))
            {
                ModelState.AddModelError("zipcode", "Zipcode Is Required");
            }



            if (!string.IsNullOrEmpty(zipcode))
            {
                if (!helper.IsNumber(zipcode))
                {
                    ModelState.AddModelError("zipcode", "Zipcode must be a number");
                }

            }


            string purchaseprice = model.purchasePrice.ToString();

            if (string.IsNullOrEmpty(purchaseprice))
            {
                ModelState.AddModelError("purchasePrice", "Purchase Price Is Required");
            }

            if (!string.IsNullOrEmpty(purchaseprice))
            {
                if (!helper.IsNumber(purchaseprice))

                {
                    ModelState.AddModelError("purchasePrice", "Zipcode must be a number");
                }

                if (helper.IsNumber(purchaseprice) && model.purchasePrice > model.vehicle.MRSP)
                {
                    ModelState.AddModelError("purchasePrice", "Purchase Price must be less than MRSP");
                }


            }




            string purchaseType = model.purchaseType.ToString();

            if (string.IsNullOrEmpty(purchaseType))
            {
                ModelState.AddModelError("purchaseType", "Purchase Type Is Required");
            }

           



            if (ModelState.IsValid)
            {
                purchaseRepo.Add(model);


                return View("SalesIndex");
            }

            else
            {
              
                return View(model);
            }

           
        }


    }
}