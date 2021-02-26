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

        public string SelectedRoleName { get; set; }

        //[DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
       [Compare("Password", ErrorMessage = "Password and confirmation do not match")]
        public string ConfirmPassword { get; set; }

        public int SelectedRoleId { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }

    }
}