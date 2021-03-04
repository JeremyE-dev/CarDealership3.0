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
            //view will contain: search bar with filter
            // sends search
            // listing of search results
            
            return View();
        }

        [HttpPost]
        public ActionResult New(NewVehicleSearchVM model)
        {
            //view will contain: search bar with filter
            // listing of search results

            return View();
        }


        [HttpGet]
        public ActionResult Used()
        {
            //view will contain: search bar with filter
            // listing of search results
            return View();
        }

        [HttpPost]
        public ActionResult Used(UsedVehicleSearchVM model)
        {
            //view will contain: search bar with filter
            // listing of search results
            return View();
        }

        [HttpGet]
        public ActionResult Details(string id)
        {
            return View();
        }

    }
}