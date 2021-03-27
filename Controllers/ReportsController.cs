using CarDealership2.Factories;
using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.Repositories;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership2.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult Index()
        {
         
            return View();
        }

        [HttpGet]
        public ActionResult SalesReport()
        {
            UserRepositoryProd UserRepo = new UserRepositoryProd();

            SalesReportVM model = new SalesReportVM();

            model.Users = from u in UserRepo.GetAll()
                                 select new SelectListItem { Text = u.UserName, Value = u.Id.ToString() };

            return View(model);
        }

        [HttpPost]
        public ActionResult SalesReport(SalesReportVM model)
        {
            ISalesReportRepository SalesRepo = SalesReportRepositoryFactory.Create();


            if (ModelState.IsValid)
            {
                //get the report from the repo
                //report wil return a list of 
                //salespeople, with their total sales and count of vehicles sold

                model.ListOfSales = SalesRepo.GetAll();

                UserRepositoryProd UserRepo = new UserRepositoryProd();

                
                model.Users = from u in UserRepo.GetAll()
                              select new SelectListItem { Text = u.UserName, Value = u.Id.ToString() };


                return View(model);
            }

            else
            {
                UserRepositoryProd UserRepo = new UserRepositoryProd();

                model.Users = from u in UserRepo.GetAll()
                              select new SelectListItem { Text = u.UserName, Value = u.Id.ToString() };

                return View(model);
            }

          
        }



        [HttpGet]
        public ActionResult InventoryReport()
        {
            IInventoryReportRepository Inventory = InventoryReportRepositoryFactory.Create();

            InventoryReportVM model = new InventoryReportVM();

            model.usedVehiclesList = Inventory.GetAllUsed();

            model.newVehiclesList = Inventory.GetAllNew();
            return View(model);
        }

    }
}