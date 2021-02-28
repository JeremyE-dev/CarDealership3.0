using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace CarDealership2.ViewModels
{
    public class TestModelVM
    {
        
        public int SelectedRoleId { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}