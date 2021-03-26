using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealership2.ViewModels
{
    public class ChangePasswordVM
    {
        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        //public string SelectedRoleName { get; set; }

        //[DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("NewPassword", ErrorMessage = "New Password and Confirmation do not match")]
        public string ConfirmNewPassword { get; set; }

        public string UserName { get; set; }
    }
}