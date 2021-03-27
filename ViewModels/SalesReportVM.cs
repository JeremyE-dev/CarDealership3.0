using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership2.ViewModels
{
    public class SalesReportVM
    {
        public List<Sale> ListOfSales = new List<Sale>();

        //list of users select lis

        public string SelectedUserId { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
    }
}