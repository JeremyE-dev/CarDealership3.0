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
            //contains links to sales report and inventory report
            return View();
        }

        public ActionResult Sales()
        {
            //contains links to sales report and inventory report
            return View();
        }

        public ActionResult Inventory()
        {
            //contains links to sales report and inventory report
            return View();
        }

    }
}