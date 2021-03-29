using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership2.ViewModels
{
    public class EditUserVM
    {
        //list of users in DB
        public string UserId { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //not required - check for null in post action
        //[Required]
        // [DataType(DataType.Password)]
        public string Password { get; set; }

        //public string SelectedRoleName { get; set; }

        //[DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password and confirmation do not match")]
        public string ConfirmPassword { get; set; }

        //get this from viewbag
        public RoleType SelectedRoleType { get; set; }

        public string selectedRoleName { get; set; }
    }
}