using CarDealership2.Factories;
using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealership2.Controllers
{
    public class HomeController : Controller
    {
        //allow anonymous is default, but best practice when writin a web
        //applicatioin that uses authentication
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            //check to see if the model is valid - did they fill in the form
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            //Load the user manager and authentication objects
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            

            // attempt to load the user with this password
            AppUser user = userManager.Find(model.UserName, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl); //returns to resource they were trying to use (after successful login)
                else
                    return RedirectToAction("Index"); //is empty - redirects to index not logged in ??
            }
        }


        public ActionResult Index()
        {
            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();
            ISpecialRepository specialsRepo = SpecialRepositoryFactory.Create();

            HomeIndexVM model = new HomeIndexVM();

            model.featuredVehicles = vehicleRepository.GetAllFeaturedVehicles().ToList();
            model.specials = specialsRepo.GetAll().ToList();
           

            return View(model);
        }

        [HttpGet]
        public ActionResult Specials()
        {
            ISpecialRepository SpecialRepo = SpecialRepositoryFactory.Create();

            SpecialsListVM model = new SpecialsListVM();

            model.specials = SpecialRepo.GetAll().ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult ContactUs()
        {
            ContactVM model = new ContactVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult ContactUs(ContactVM model) //need contacts repository
        {
            IContactRepository ContactRepo = ContactRepositoryFactory.Create();


            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Name Is Required");
            }

            if (string.IsNullOrEmpty(model.Email) && string.IsNullOrEmpty(model.Phone))
            {
                ModelState.AddModelError("Phone", "either email or phone is required");
            }



            if (ModelState.IsValid)
            {
                ContactRepo.Add(model);

                //call add

                return RedirectToAction("ContactUs");
            }

            else
            {
                return View(model);
            }
            
           

            
        }



    }
}