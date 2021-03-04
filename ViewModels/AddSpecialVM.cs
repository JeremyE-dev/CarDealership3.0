using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.ViewModels
{
    public class AddSpecialVM
    {
        public Special special { get; set; }

        public List<Special> specials { get; set; }

        public AddSpecialVM()
        {
            special = new Special();
            specials = new List<Special>();
            special.Title = "";
            special.Description = "";

        }
    }
}