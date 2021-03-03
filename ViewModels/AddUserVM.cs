using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompareAttribute = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace CarDealership2.ViewModels
{
    public class AddUserVM
    {


        //list of users in DB
        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
       // [DataType(DataType.Password)]
        public string Password { get; set; }

        //public string SelectedRoleName { get; set; }

       [DataType(DataType.Password)]
       [Display(Name = "Confirm password")]
       [Compare("Password", ErrorMessage = "Password and confirmation do not match")]
        public string ConfirmPassword { get; set; }

        //get this from viewbag
        public RoleType SelectedRoleType { get; set; }

        //public int SelectedRoleId { get; set; }

        //public IEnumerable<SelectListItem> Roles { get; set; }

        //public LocalRole SelectedRole { get; set; }


        //public List<string> rolenames { get; set; }


        //public AddUserVM()
        //{
        //    SelectedRoleId = 0;
        //}


        //public void SetRoleNames()
        //{
        //    rolenames = new List<string>();

        //    CarDealership2DbContext db = new CarDealership2DbContext();

        //    foreach(AppRole x in db.Roles)
        //    {
        //        rolenames.Add(x.Name);
        //    }
        //}


    }




   

}