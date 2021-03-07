using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.ViewModels
{
    public class VehicleSearchVM
    {
        public string SearchTerm { get; set; }

        public int PriceMin { get; set; }

        public int PriceMax { get; set; }

        public int YearMin { get; set; }

        public int YearMax { get; set; }

        public List<Vehicle> vehicles { get; set; }

    }
}