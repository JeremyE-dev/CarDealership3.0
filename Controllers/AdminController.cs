using CarDealership2.Factories;
using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.Repositories;
using CarDealership2.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

//using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;
using System.Web;
//using System.Web.Http;
using System.Web.Mvc;

namespace CarDealership2.Controllers
{
    //[Authorize(Roles = "admin")]
    public class AdminController : Controller
    {


        [HttpGet]
        public ActionResult Makes()
        {
            //this should list the makes that exist
            var model = new AddMakeVM();
            //add list to model
            //get email address
            model.makes = MakeRepositoryFactory.Create().GetAll().ToList();

            return View(model);
        }


        [HttpPost]
        public ActionResult Makes(AddMakeVM model)
        {
            //here model has currect list
            //create new instance of make repository
            //this needs to 
            IMakeRepository MakeRepo = MakeRepositoryFactory.Create();




            if (string.IsNullOrEmpty(model.make.MakeName))
            {

                ModelState.AddModelError("make.MakeName", "Please Enter a Make Name");



            }
            //note: success writing to db, not displaying view only displaying after second save
            // set breakpoints: either controller iss or view

            if (ModelState.IsValid)
            {

                model.makes = MakeRepo.GetAll().ToList();

                model.currentUsername = User.Identity.GetUserName();

                MakeRepositoryFactory.Create().Add(model.make.MakeName, model.currentUsername);

                return RedirectToAction("Makes", model);
            }

            else
            {

                model.makes = MakeRepo.GetAll().ToList();
                return View("Makes", model);
            }
        }

        [HttpGet]

        public ActionResult Test()
        {

            return View();
        }

        public ActionResult JQueryTest()
        {
            return View();
        }

        public ActionResult JSTest()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Test(RoleModel model)
        {
            var selectedValue = model.SelectedRoleType;

            ViewBag.RoleType = selectedValue.ToString();


            return View();

        }



        [HttpGet]
        public ActionResult Models()
        {

            var model = new AddModelVM();


            var makeRepository = MakeRepositoryFactory.Create();

            //populates list of models
            model.models = ModelRepositoryFactory.Create().GetAll().ToList(); //this could be null - no seed data

            //populates drop down - I think :)
            model.Makes = from m in makeRepository.GetAll()
                          select new SelectListItem { Text = m.MakeName, Value = m.MakeId.ToString() };

            return View(model);
        }

        [HttpPost]
        public ActionResult Models(AddModelVM model)
        {

            IModelRepository ModelRepo = ModelRepositoryFactory.Create();

            var makeRepository = MakeRepositoryFactory.Create();

            var repository = ModelRepositoryFactory.Create();

            if (string.IsNullOrEmpty(model.vehicleModel.ModelName))
            {

                ModelState.AddModelError("vehicleModel.ModelName", "Please Enter a Model Name");

            }

            if (ModelState.IsValid)
            {

                model.models = ModelRepo.GetAll().ToList();
                model.currentUsername = User.Identity.GetUserName();


                ModelRepositoryFactory.Create().Add(model);

                return RedirectToAction("Models", model);
            }

            else
            {

                model.models = ModelRepo.GetAll().ToList();
                model.Makes = from m in makeRepository.GetAll()
                              select new SelectListItem { Text = m.MakeName, Value = m.MakeId.ToString() };

                return View("Models", model);
            }

        }



        [HttpGet]
        public ActionResult Users()
        {

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();

            var model = new UsersVM();
            model.UserList = (IEnumerable<AppUser>)UserRepositoryFactory.Create().GetAll().ToList();

            foreach (AppUser x in model.UserList)
            {
                //checkt this out
                //why is th seco
                x.RoleName = userManager.GetRoles(x.Id.ToString()).FirstOrDefault();
            }
            return View(model);

        }

        [HttpGet]
        public ActionResult AddUser()
        {
            AddUserVM model = new AddUserVM();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddUser(AddUserVM model)
        {

            //UserRepositoryProd UserRepo = new UserRepositoryProd();

            IUserRepository UserRepo = UserRepositoryFactory.Create();

            var selectedValue = model.SelectedRoleType;

            ViewBag.RoleType = selectedValue.ToString();

            if (string.IsNullOrEmpty(model.FirstName))
            {
                ModelState.AddModelError("FirstName", "First Name is Required");
            }

            if (string.IsNullOrEmpty(model.LastName))
            {
                ModelState.AddModelError("LastName", "First Name is Required");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "Email is Required");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "Password is Required");
            }

            if (string.IsNullOrEmpty(model.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Confirm Password is Required");
            }



            if (ModelState.IsValid)
            {
                UserRepo.Add(model);
                return RedirectToAction("AddUser", model);
            }

            else
            {

                return View("AddUser", model);
            }



        }

        [HttpGet]
        public ActionResult EditUser(string id)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();

            var user = userManager.FindById(id);

            EditUserVM model = new EditUserVM();

            model.UserId = "";

            //populate view fields with information from user
            model.UserId = user.Id;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.Email = user.Email;
            //populate dropdown with the current role via attribure
            //do not populate password and confirm password
            // if no password is supplied in post do not change it
            // if it is suppled then change it
            return View("EditUser", model);
        }


        [HttpPost]
        public ActionResult EditUser(EditUserVM model)
        {
            UserRepositoryProd UserRepo = new UserRepositoryProd();

            var selectedValue = model.SelectedRoleType;

            ViewBag.RoleType = selectedValue.ToString();

            //errors - check for empty fields
            if (string.IsNullOrEmpty(model.FirstName))
            {
                ModelState.AddModelError("FirstName", "First Name is Required");
            }

            if (string.IsNullOrEmpty(model.LastName))
            {
                ModelState.AddModelError("LastName", "First Name is Required");
            }

            if (string.IsNullOrEmpty(model.Email))
            {
                ModelState.AddModelError("Email", "Email is Required");
            }

            if (ModelState.IsValid)
            {
                UserRepo.Edit(model); //in edit - if password and is not null -- update it
                return RedirectToAction("Users");
            }

            else
            {

                //add error messages
                return View("EditUser", model);
            }
        }

        [HttpGet]
        public ActionResult Vehicles()
        {
            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();

            //VehicleSearchVM model = new VehicleSearchVM();
            List<Vehicle> VehicleList = new List<Vehicle>();

             VehicleList = vehicleRepository.GetAll().ToList();

            return View(VehicleList);


        }
        [HttpGet]
        public ActionResult GetAllVehicles()
        {
            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();
     
            List<Vehicle>VehicleRepoList = vehicleRepository.GetAll().ToList();

            ViewBag.List = VehicleRepoList; // could I loop through this 

            
            return Json(VehicleRepoList, JsonRequestBehavior.AllowGet);

        }

       

        [Route("GetVehicleSearchResults/{searchTerm}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        //[Route("GetVehicleSearchResults/{searchTerm}/{}")]
        [HttpGet]
        public ActionResult GetVehicleSearchResults(string searchTerm , int minPrice, int maxPrice, int minYear, int maxYear)
        {
           
            
            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();
            List<Vehicle> VehicleRepoList = new List<Vehicle>();

            //if all fields are empty return all of the vehicles

            if (searchTerm == "0" && minPrice == 0 && maxPrice == 0 && minYear == 0 && maxYear == 0) 
            {
                VehicleRepoList = vehicleRepository.GetAll().ToList();
            }

            else
            {
                VehicleRepoList = vehicleRepository.GetAll().ToList();
            }

          

            ViewBag.List = VehicleRepoList; // could I loop through this 


            return Json(VehicleRepoList, JsonRequestBehavior.AllowGet);

        }




        [HttpGet]
        public ActionResult AddVehicle()
        {
            //create empty view model
            var model = new AddVehicleVM();

            //create copies of needed repositories
            var makeRepository = MakeRepositoryFactory.Create();
            var modelRepository = ModelRepositoryFactory.Create();
            var vehicleTypeRepository = VehicleTypeRepositoryFactory.Create();
            var bodystyleRepository = BodyStyleRepositoryFactory.Create();
            var transmissionRepository = TransmissionRepositoryFactory.Create();
            var colorRepository = ColorRepositoryFactory.Create();
            var interiorRepository = InteriorRepositoryFactory.Create();


            //populate selectlists for dropdowns
            model.Makes = from m in makeRepository.GetAll()
                          select new SelectListItem { Text = m.MakeName, Value = m.MakeId.ToString() };
           
            model.VehicleModels = from m in modelRepository.GetAll()
                                  select new SelectListItem { Text = m.ModelName, Value = m.ModelId.ToString() };
            
            model.VehicleTypes = from m in vehicleTypeRepository.GetAll()
                                  select new SelectListItem { Text = m.VehicleTypeName, Value = m.VehicleTypeId.ToString() };

            model.BodyStyles = from m in bodystyleRepository.GetAll()
                                 select new SelectListItem { Text = m.BodyStyleName, Value = m.BodyStyleId.ToString() };

            model.Transmissions = from m in transmissionRepository.GetAll()
                                  select new SelectListItem { Text = m.TransmissionName, Value = m.TransmissionId.ToString() };

            model.Colors = from m in colorRepository.GetAll()
                           select new SelectListItem { Text = m.ColorName, Value = m.ColorId.ToString() };
           
            model.Interiors = from m in interiorRepository.GetAll()
                           select new SelectListItem { Text = m.InteriorName, Value = m.InteriorId.ToString() };




            return View(model);
        }


        [HttpPost]
        public ActionResult AddVehicle(AddVehicleVM model)
        {
            //add validation 
            //year null and valid year
            //Mileage null - must be a number
            //vin# - null
            //mrsp- null
            //sale -price - null
            // sale price not more than MRSP
          
            
            
            
            IVehicleRepository VehicleRepo = VehicleRepositoryFactory.Create();
            
            if (ModelState.IsValid)
            {
               VehicleRepo.Add(model);

                return RedirectToAction("AddVehicle", model);
            }

            else
            {
                return View(model);

            }

           
         
        }

        [HttpGet]
        public ActionResult EditVehicle()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EditVehicle(EditVehicleVM model)
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteVehicle(int id)
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddSpecial()
        {
            ISpecialRepository SpecialRepo = SpecialRepositoryFactory.Create();

            AddSpecialVM model = new AddSpecialVM();

            model.specials = SpecialRepo.GetAll().ToList();


            return View(model);
        }


        [HttpPost]
        public ActionResult AddSpecial(AddSpecialVM model)
        {
            ISpecialRepository SpecialRepo = SpecialRepositoryFactory.Create();
            SpecialRepo.Add(model);
            model.specials = SpecialRepo.GetAll().ToList();
            return View("AddSpecial", model);
        }

        [HttpGet]
        public ActionResult DeleteSpecial(int id)
        {
            ISpecialRepository SpecialRepo = SpecialRepositoryFactory.Create();

            AddSpecialVM model = new AddSpecialVM();

           
          
            SpecialRepo.Delete(id);
            model.specials = SpecialRepo.GetAll().ToList();

            return View("AddSpecial",model);

        }


    }
    }



