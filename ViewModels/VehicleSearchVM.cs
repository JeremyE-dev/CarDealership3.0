using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership2.ViewModels
{
    public class VehicleSearchVM
    {
        public string SearchTerm { get; set; }
        public string BodyStlye { get; set; }

        public string Interior { get; set; }

        public int SalePrice { get; set; }

        public int MRSP { get; set; }

        public string Transmission { get; set; }

        public int Mileage { get; set; }

        public string Color { get; set; }

        public string VIN { get; set; }





    }
}