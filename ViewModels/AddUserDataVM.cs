using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership2.ViewModels
{
    public class AddUserDataVM
    {
        //one user
        public UserData user { get; set; }

        //list of users in DB
        public List<UserData> users { get; set; }
        public int SelectedRoleId { get; set; }

        public string ConfirmPassword { get; set; }

        public IEnumerable<SelectListItem> Roles { get; set; }
    }
}