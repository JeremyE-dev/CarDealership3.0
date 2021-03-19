using CarDealership2.Factories;
using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership2.Controllers
{
    public class InventoryController : Controller
    {
        // GET: Inventory
        [HttpGet]
        public ActionResult New()
        {
            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();
            List<Vehicle> VehicleList = new List<Vehicle>();

            VehicleList = vehicleRepository.GetAllNewVehicles().ToList();

            return View(VehicleList);

           
        }

        [Route("GetNewVehicleSearchResults/{searchTerm}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        //[Route("GetVehicleSearchResults/{searchTerm}/{}")]
        [HttpGet]
        public ActionResult GetNewVehicleSearchResults(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {


            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();
            List<Vehicle> VehicleRepoList = new List<Vehicle>();

            //if all fields are empty return all of the vehicles

            if (searchTerm == "0" && minPrice == 0 && maxPrice == 0 && minYear == 0 && maxYear == 0)
            {
                VehicleRepoList = vehicleRepository.GetAllNewVehicles().ToList();
            }

            else
            {
                VehicleRepoList = vehicleRepository.SearchNewVehicles(searchTerm, minPrice, maxPrice, minYear, maxYear).ToList();
            }



            ViewBag.List = VehicleRepoList; // could I loop through this 


            return Json(VehicleRepoList, JsonRequestBehavior.AllowGet);

        }

        //[HttpPost]
        //public ActionResult New(NewVehicleSearchVM model)
        //{
        //    //view will contain: search bar with filter
        //    // listing of search results

        //    return View();
        //}


        [HttpGet]
        public ActionResult Used()
        {
            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();
            List<Vehicle> VehicleList = new List<Vehicle>();

            VehicleList = vehicleRepository.GetAllUsedVehicles().ToList();

            return View(VehicleList);
        }

        [Route("GetUsedVehicleSearchResults/{searchTerm}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        //[Route("GetVehicleSearchResults/{searchTerm}/{}")]
        [HttpGet]
        public ActionResult GetUsedVehicleSearchResults(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {


            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();
            List<Vehicle> VehicleRepoList = new List<Vehicle>();

            //if all fields are empty return all of the vehicles

            if (searchTerm == "0" && minPrice == 0 && maxPrice == 0 && minYear == 0 && maxYear == 0)
            {
                VehicleRepoList = vehicleRepository.GetAllUsedVehicles().ToList();
            }

            else
            {
                VehicleRepoList = vehicleRepository.SearchUsedVehicles(searchTerm, minPrice, maxPrice, minYear, maxYear).ToList();
            }



            ViewBag.List = VehicleRepoList; // could I loop through this 


            return Json(VehicleRepoList, JsonRequestBehavior.AllowGet);

        }


        //[HttpPost]
        //public ActionResult Used(UsedVehicleSearchVM model)
        //{
        //    //view will contain: search bar with filter
        //    // listing of search results
        //    return View();
        //}

        [HttpGet]
        public ActionResult Details(int id)
        {
            IVehicleRepository VehicleRepo = VehicleRepositoryFactory.Create();

            Vehicle vehicleToShow = VehicleRepo.GetVehicleById(id);

            return View(vehicleToShow);
        }

    }
}