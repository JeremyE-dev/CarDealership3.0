﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.ViewModels
{
    public class ContactVM
    {
       
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }

        public string Message { get; set; }

    }
}