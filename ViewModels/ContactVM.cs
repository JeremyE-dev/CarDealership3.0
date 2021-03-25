using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership2.ViewModels
{
    public class ContactVM
    {

     
        public string Name { get; set; }

        
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        
        
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        public string Message { get; set; }

    }
}