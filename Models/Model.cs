using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Models
{
    public class Model
    {
        public int ModelId { get; set; }
        public string ModelName { get; set; }

        public int? MakeId { get; set; }
        public string MakeName { get; set; }
        public string DateAdded { get; set; }
        public string currentUserEmail { get; set; }

       





        //the user who added the vehicle


        //doing this, can do things like Make.User.Email, 

        //public virtual Make Make { get; set; }
    }
}