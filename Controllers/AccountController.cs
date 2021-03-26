using CarDealership2.Factories;
using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership2.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            
            ChangePasswordVM model = new ChangePasswordVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordVM model)
        {

            model.UserName = User.Identity.GetUserName();

            //var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();

            IUserRepository UserRepo = UserRepositoryFactory.Create();


            if (string.IsNullOrEmpty(model.OldPassword))
            {
                ModelState.AddModelError("OldPassword", " Old Password Is Required");
            }


            if (string.IsNullOrEmpty(model.NewPassword))
            {
                ModelState.AddModelError("NewPassword", " New Password Is Required");
            }

            if (string.IsNullOrEmpty(model.ConfirmNewPassword))
            {
                ModelState.AddModelError("ConfirmNewPassword", "Confirm Password Is required");
            }

            if (string.IsNullOrEmpty(model.NewPassword) && string.IsNullOrEmpty(model.ConfirmNewPassword))
            {

                if (!string.Equals(model.NewPassword, model.ConfirmNewPassword))
                {
                    ModelState.AddModelError("ConfirmPassword"," New Password and Confirm Password Must Match");
                }
            }



            if (ModelState.IsValid)
            {
                UserRepo.ChangePassword(model);


                return View(model);
            }

            else
            {
                return View(model);
            }

        }
    }
}