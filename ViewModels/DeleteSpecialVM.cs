using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.ViewModels
{
    public class DeleteSpecialVM
    {
        public Special special { get; set; }

        public List<Special> specials { get; set; }
    }
}