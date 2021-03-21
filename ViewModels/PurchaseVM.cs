using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership2.ViewModels
{
    public class PurchaseVM
    {
        public Vehicle vehicle { get; set; }

        public string name { get; set; }

        public int phone { get; set; }

        public string email { get; set; }

        public string street1 { get; set; }
        public string street2 { get; set; }

        public string city { get; set; }

        //public List<string> _states { get; set; }

        public int zipcode { get; set; }

        public int purchasePrice { get; set; }

        //public int SelectedStateId { get; set; }

        public State purchaseState { get; set; }

        //public IEnumerable<SelectListItem> States { get; set; }



        public DateTime purchaseDate { get; set; }

        //public int salesPersonId { get; set; }

        public AppUser salesPerson { get; set; }

        public PurchaseVM()
        {
            //_states = new List<string>();
            //foreach(State s in Enum.GetValues(typeof(State))) {
            //    _states.Add(s.ToString());
            //}

            salesPerson = new AppUser();

        }



    }
}
