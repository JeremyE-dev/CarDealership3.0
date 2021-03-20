using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public Vehicle purchasedVehicle { get; set; }

        public string name { get; set; }

        public int phone { get; set; }

        public string email { get; set; }

        public string street1 { get; set; }
        public string street2 { get; set; }

        public string city { get; set; }

      

        public int zipcode { get; set; }

        public int purchasePrice { get; set; }

       

        public State purchaseState { get; set; }

        //public IEnumerable<SelectListItem> States { get; set; }



        public DateTime purchaseDate { get; set; }

        public AppUser salesPerson { get; set; }

        public Purchase()
        {
           
            salesPerson = new AppUser();

        }

        public virtual Vehicle vehicle { get; set; }
    }
}