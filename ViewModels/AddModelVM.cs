using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership2.ViewModels
{
    public class AddModelVM
    {
        public Model vehicleModel { get; set; }

        public string currentUserEmail { get; set; }

        public string currentUsername { get; set; }

        //public Make SelectedMake { get; set; }
        public List<Model> models { get; set; }


        //need to add select lo

        //not sure what role this plays - this hold the items to select from
        

        public string SelectedMakeId { get; set; }
        public IEnumerable<SelectListItem> Makes { get; set; }

        public AddModelVM()
        {
            vehicleModel = new Model();
            models = new List<Model>();
            currentUserEmail = "";
            SelectedMakeId = "";

        }
    }
}