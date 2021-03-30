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
using CarDealership2.Helpers;
using System.IO;

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

            if (string.IsNullOrEmpty(model.SelectedMakeId))
            {

                ModelState.AddModelError("SelectedMakeId", "Please Select A Make");

            }



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

            //1.) get object
            //2.) create new model
            //3.) populate new model with input from user
            //4.) return View ("EditUser", model) sends the updated model to edit post method
            //5.) post does the editing and saves the changes
            
            //get object
            var user = userManager.FindById(id);

            //create new model
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
                ModelState.AddModelError("LastName", "Last Name is Required");
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
                VehicleRepoList = vehicleRepository.SearchVehicles(searchTerm,minPrice,maxPrice,minYear,maxYear).ToList();
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
            //*VALIDATION*
            //dropdowns selection is required
            //Make, Model, Type, Body Style, Transmission, Color, Interior

            //other inputs:
            //Year - required must be a number, must be less than 3000, and greater than 1900
            Helper helper = new Helper();

            var makeRepository = MakeRepositoryFactory.Create();
            var modelRepository = ModelRepositoryFactory.Create();
            var vehicleTypeRepository = VehicleTypeRepositoryFactory.Create();
            var bodystyleRepository = BodyStyleRepositoryFactory.Create();
            var transmissionRepository = TransmissionRepositoryFactory.Create();
            var colorRepository = ColorRepositoryFactory.Create();
            var interiorRepository = InteriorRepositoryFactory.Create();

            //if a file was uploaded and that file has content
            if(model.UploadedFile != null && model.UploadedFile.ContentLength> 0)
            {
                // combine the path on the server with the filename uploaded
                string path = Path.Combine(Server.MapPath("~/Uploads"), Path.GetFileName(model.UploadedFile.FileName));

                //upload thr file to that path
                model.UploadedFile.SaveAs(path);
                // save the file name to the  photopath field
                // thsi is a workaround, wa sgetting JS error saying not allwed to upload get local file when using whole filename
                //workaround is combine path and filename in JS file via jquery
                model.Vehicle.PhotoPath = Path.GetFileName(model.UploadedFile.FileName);
            }

            if (string.IsNullOrEmpty(model.SelectedMakeId))
            {

                ModelState.AddModelError("SelectedMakeId", "Please Select A Make");

            }

            if (string.IsNullOrEmpty(model.SelectedVehicleModelId))
            {

                ModelState.AddModelError("SelectedVehicleModelId", "Please Select A Model");

            }


            if (string.IsNullOrEmpty(model.SelectedVehicleTypeId))
            {

                ModelState.AddModelError("SelectedVehicleTypeId", "Please Select A Type");

            }

            if (string.IsNullOrEmpty(model.SelectedBodyStyleId))
            {

                ModelState.AddModelError("SelectedBodyStyleId", "Please Select A Body Style");

            }

            if (string.IsNullOrEmpty(model.SelectedTransmissionId))
            {

                ModelState.AddModelError("SelectedTransmissionId", "Please Select A Transmission");

            }


            if (string.IsNullOrEmpty(model.SelectedColorId))
            {

                ModelState.AddModelError("SelectedColorId", "Please Select A Color");

            }

            if (string.IsNullOrEmpty(model.SelectedInteriorId))
            {

                ModelState.AddModelError("SelectedInteriorId", "Please Select An Interior");

            }



            string mileage = model.Vehicle.Mileage.ToString();

            if (string.IsNullOrEmpty(mileage))
            {
                ModelState.AddModelError("Mileage", "Mileage is required");

               
            }

            if (!string.IsNullOrEmpty(mileage))
            {
                if (!helper.IsNumber(mileage))
                {
                    ModelState.AddModelError("Mileage", "Mileage input must be an integer");

                    if (model.Vehicle.Mileage < 0)
                    {
                        ModelState.AddModelError("Mileage", "Please enter a valid number");
                    }
                }

            }

        

            int vehicleTypeId = Convert.ToInt32(model.SelectedVehicleTypeId);

            VehicleType vehicleType = new VehicleType();

            vehicleType = vehicleTypeRepository.GetAll().FirstOrDefault(t => t.VehicleTypeId == vehicleTypeId);

            

            if (!string.IsNullOrEmpty(model.SelectedVehicleTypeId))
            {
                if (vehicleType.VehicleTypeName == "New")
                {
                    if (!string.IsNullOrEmpty(mileage) && model.Vehicle.Mileage > 1000 || model.Vehicle.Mileage < 0)
                    {
                        ModelState.AddModelError("Vehicle.Mileage", "Mileage Must Be Under 1000 if New");
                    }
                    
                }
            }

            if (!string.IsNullOrEmpty(model.SelectedVehicleTypeId))
            {
                if (vehicleType.VehicleTypeName == "Used")
                {
                    if (!string.IsNullOrEmpty(mileage) && model.Vehicle.Mileage < 1000 || model.Vehicle.Mileage < 0)
                    {
                        ModelState.AddModelError("Vehicle.Mileage", "Mileage Must Be Over 1000 if New");
                    }

                }
            }


            if (string.IsNullOrEmpty(model.Vehicle.VIN))
            {
                ModelState.AddModelError("Vehicle.VIN", "VIN is required");
            }

            string year = model.Vehicle.Year.ToString();

            if (string.IsNullOrEmpty(year))
            {
                ModelState.AddModelError("Vehicle.Year", "Year is required");
            }

            if (!string.IsNullOrEmpty(year))
            {
                if (!helper.IsNumber(mileage))
                {
                    ModelState.AddModelError("Vehicle.Year", "Year must be a number");
                }

                if (helper.IsNumber(mileage) && model.Vehicle.Year < 2000 || model.Vehicle.Year > DateTime.Now.Year + 1)
                {
                    ModelState.AddModelError("Vehicle.Year", "Please Enter a Valid Year");
                }

            }

            string mrsp = model.Vehicle.MRSP.ToString();

            if (string.IsNullOrEmpty(mrsp))
            {

                ModelState.AddModelError("Vehicle.MRSP", "MRSP is required");
           

            }

            if (!string.IsNullOrEmpty(mrsp))
            {
                if (!helper.IsNumber(mrsp))
                {
                    ModelState.AddModelError("Vehicle.MRSP", "MRSP Must Be A Number");
                }    

            }
            
            string saleprice = model.Vehicle.SalePrice.ToString();


            if (string.IsNullOrEmpty(saleprice))
            {

                ModelState.AddModelError("Vehicle.SalePrice", "Sale Price Is Required");


            }


            if (!string.IsNullOrEmpty(saleprice))
            {
                if (!helper.IsNumber(saleprice))
                {
                    ModelState.AddModelError("Vehicle.SalePrice", "Sale Price Must Be A Number");
                }

            }

            if(!string.IsNullOrEmpty(mrsp) && !string.IsNullOrEmpty(saleprice))
            {
                if (helper.IsNumber(mrsp) && !helper.IsNumber(saleprice))
                {
                    if (model.Vehicle.SalePrice > model.Vehicle.MRSP)
                    {
                        ModelState.AddModelError("Vehicle.SalePrice", "Sale Price Must Be Less Than MRSP");
                    }
                }
            }


            if (string.IsNullOrEmpty(model.Vehicle.Description))
            {

                ModelState.AddModelError("Vehicle.Description", "Description Is Required");


            }



            IVehicleRepository VehicleRepo = VehicleRepositoryFactory.Create();

            if (ModelState.IsValid)
            {
                VehicleRepo.Add(model);

                var lastvehicle = VehicleRepo.GetAll().Last();

                int id = lastvehicle.VehicleId;

                return RedirectToAction("EditVehicle/"+ id, "Admin");
            }

            else
            {
            


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

                //return View(model);

                return View ("AddVehicle", model);

            }

           
         
        }

        [HttpGet]
        public ActionResult EditVehicle(int id)
        {
            //get the repo
            IVehicleRepository VehicleRepo = VehicleRepositoryFactory.Create();
            //get the vehicle to edit and pass it to the view

            //create copies of needed repositories
            var makeRepository = MakeRepositoryFactory.Create();
            var modelRepository = ModelRepositoryFactory.Create();
            var vehicleTypeRepository = VehicleTypeRepositoryFactory.Create();
            var bodystyleRepository = BodyStyleRepositoryFactory.Create();
            var transmissionRepository = TransmissionRepositoryFactory.Create();
            var colorRepository = ColorRepositoryFactory.Create();
            var interiorRepository = InteriorRepositoryFactory.Create();

            Vehicle vehicleToEdit = VehicleRepo.GetVehicleById(id);

            EditVehicleVM model = new EditVehicleVM();
            model.Vehicle = new Vehicle();
            model.Vehicle = vehicleToEdit; // is the Vehcile found have a null make here
            model.Vehicle.VehicleId = vehicleToEdit.VehicleId;

            //set the the EditViewModels selection ids to match vehicleToEdit
            // why is vehicle id zero when it is passed to post contoller????
           
            model.Vehicle.Make = new Make();
            model.Vehicle.Make = vehicleToEdit.Make;
            model.selectedMakeName = model.Vehicle.MakeName;

            model.Vehicle.VehicleModel = new Model();
            model.Vehicle.VehicleModel = vehicleToEdit.VehicleModel;
            model.selectedModelName = model.Vehicle.VehicleModelName;

            model.Vehicle.Type = new VehicleType();
            model.Vehicle.Type = vehicleToEdit.Type;
            model.selectedVehicleTypeName = model.Vehicle.VehicleTypeName;


            model.Vehicle.BodyStyle = new BodyStyle();
            model.Vehicle.BodyStyle = vehicleToEdit.BodyStyle;
            model.selectedBodyStyleName = model.Vehicle.BodyStyleName;

            model.Vehicle.Year = vehicleToEdit.Year;

            model.Vehicle.Transmission = new Transmission();
            model.Vehicle.Transmission = vehicleToEdit.Transmission;
            model.selectedTransmissionName = model.Vehicle.TransmissionName;

            model.Vehicle.Color = new Color();
            model.Vehicle.Color = vehicleToEdit.Color;
            model.selectedColorName = model.Vehicle.ColorName;

            model.Vehicle.Interior = new Interior();
            model.Vehicle.Interior = vehicleToEdit.Interior;
            model.selectedInteriorName = model.Vehicle.InteriorName;

            model.Vehicle.Mileage = vehicleToEdit.Mileage;
            
            model.Vehicle.VIN = vehicleToEdit.VIN;
            
            model.Vehicle.MRSP = vehicleToEdit.MRSP;
            
            model.Vehicle.SalePrice = vehicleToEdit.SalePrice;
            
            model.Vehicle.Description = vehicleToEdit.Description;
            
            model.Vehicle.IsFeatured = vehicleToEdit.IsFeatured;


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

            

            return View("EditVehicle", model);
        }


        [HttpPost]

        public ActionResult EditVehicle(EditVehicleVM model, int id)
        {
            model.Vehicle.VehicleId = id;

            IVehicleRepository VehicleRepo = VehicleRepositoryFactory.Create();
            var makeRepository = MakeRepositoryFactory.Create();
            var modelRepository = ModelRepositoryFactory.Create();
            var vehicleTypeRepository = VehicleTypeRepositoryFactory.Create();
            var bodystyleRepository = BodyStyleRepositoryFactory.Create();
            var transmissionRepository = TransmissionRepositoryFactory.Create();
            var colorRepository = ColorRepositoryFactory.Create();
            var interiorRepository = InteriorRepositoryFactory.Create();


            //if a file was uploaded and that file has content
            if (model.UploadedFile != null && model.UploadedFile.ContentLength > 0)
            {
                // combine the path on the server with the filename uploaded
                string path = Path.Combine(Server.MapPath("~/Uploads"), Path.GetFileName(model.UploadedFile.FileName));

                //upload thr file to that path
                model.UploadedFile.SaveAs(path);
                // save the file name to the  photopath field
                // thsi is a workaround, wa sgetting JS error saying not allwed to upload get local file when using whole filename
                //workaround is combine path and filename in JS file via jquery
                model.Vehicle.PhotoPath = Path.GetFileName(model.UploadedFile.FileName);
            }

            Helper helper = new Helper();

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


            //*BEGIN ERROR MESSAGES


            if (string.IsNullOrEmpty(model.SelectedMakeId))
            {

                ModelState.AddModelError("SelectedMakeId", "Please Select A Make");

            }

            if (string.IsNullOrEmpty(model.SelectedVehicleModelId))
            {

                ModelState.AddModelError("SelectedVehicleModelId", "Please Select A Model");

            }


            if (string.IsNullOrEmpty(model.SelectedVehicleTypeId))
            {

                ModelState.AddModelError("SelectedVehicleTypeId", "Please Select A Type");

            }

            if (string.IsNullOrEmpty(model.SelectedBodyStyleId))
            {

                ModelState.AddModelError("SelectedBodyStyleId", "Please Select A Body Style");

            }

            if (string.IsNullOrEmpty(model.SelectedTransmissionId))
            {

                ModelState.AddModelError("SelectedTransmissionId", "Please Select A Transmission");

            }


            if (string.IsNullOrEmpty(model.SelectedColorId))
            {

                ModelState.AddModelError("SelectedColorId", "Please Select A Color");

            }

            if (string.IsNullOrEmpty(model.SelectedInteriorId))
            {

                ModelState.AddModelError("SelectedInteriorId", "Please Select An Interior");

            }



            string mileage = model.Vehicle.Mileage.ToString();

            if (string.IsNullOrEmpty(mileage))
            {
                ModelState.AddModelError("Mileage", "Mileage is required");


            }

            if (!string.IsNullOrEmpty(mileage))
            {
                if (!helper.IsNumber(mileage))
                {
                    ModelState.AddModelError("Mileage", "Mileage input must be an integer");

                    if (model.Vehicle.Mileage < 0)
                    {
                        ModelState.AddModelError("Mileage", "Please enter a valid number");
                    }
                }

            }



            int vehicleTypeId = Convert.ToInt32(model.SelectedVehicleTypeId);

            VehicleType vehicleType = new VehicleType();

            vehicleType = vehicleTypeRepository.GetAll().FirstOrDefault(t => t.VehicleTypeId == vehicleTypeId);



            if (!string.IsNullOrEmpty(model.SelectedVehicleTypeId))
            {
                if (vehicleType.VehicleTypeName == "New")
                {
                    if (!string.IsNullOrEmpty(mileage) && model.Vehicle.Mileage > 1000 || model.Vehicle.Mileage < 0)
                    {
                        ModelState.AddModelError("Vehicle.Mileage", "Mileage Must Be Under 1000 if New");
                    }

                }
            }

            if (!string.IsNullOrEmpty(model.SelectedVehicleTypeId))
            {
                if (vehicleType.VehicleTypeName == "Used")
                {
                    if (!string.IsNullOrEmpty(mileage) && model.Vehicle.Mileage < 1000 || model.Vehicle.Mileage < 0)
                    {
                        ModelState.AddModelError("Vehicle.Mileage", "Mileage Must Be Over 1000 if New");
                    }

                }
            }


            if (string.IsNullOrEmpty(model.Vehicle.VIN))
            {
                ModelState.AddModelError("Vehicle.VIN", "VIN is required");
            }

            string year = model.Vehicle.Year.ToString();

            if (string.IsNullOrEmpty(year))
            {
                ModelState.AddModelError("Vehicle.Year", "Year is required");
            }

            if (!string.IsNullOrEmpty(year))
            {
                if (!helper.IsNumber(mileage))
                {
                    ModelState.AddModelError("Vehicle.Year", "Year must be a number");
                }

                if (helper.IsNumber(mileage) && model.Vehicle.Year < 2000 || model.Vehicle.Year > DateTime.Now.Year + 1)
                {
                    ModelState.AddModelError("Vehicle.Year", "Please Enter a Valid Year");
                }

            }

            string mrsp = model.Vehicle.MRSP.ToString();

            if (string.IsNullOrEmpty(mrsp))
            {

                ModelState.AddModelError("Vehicle.MRSP", "MRSP is required");


            }

            if (!string.IsNullOrEmpty(mrsp))
            {
                if (!helper.IsNumber(mrsp))
                {
                    ModelState.AddModelError("Vehicle.MRSP", "MRSP Must Be A Number");
                }

            }

            string saleprice = model.Vehicle.SalePrice.ToString();


            if (string.IsNullOrEmpty(saleprice))
            {

                ModelState.AddModelError("Vehicle.SalePrice", "Sale Price Is Required");


            }


            if (!string.IsNullOrEmpty(saleprice))
            {
                if (!helper.IsNumber(saleprice))
                {
                    ModelState.AddModelError("Vehicle.SalePrice", "Sale Price Must Be A Number");
                }

            }

            if (!string.IsNullOrEmpty(mrsp) && !string.IsNullOrEmpty(saleprice))
            {
                if (helper.IsNumber(mrsp) && !helper.IsNumber(saleprice))
                {
                    if (model.Vehicle.SalePrice > model.Vehicle.MRSP)
                    {
                        ModelState.AddModelError("Vehicle.SalePrice", "Sale Price Must Be Less Than MRSP");
                    }
                }
            }


            if (string.IsNullOrEmpty(model.Vehicle.Description))
            {

                ModelState.AddModelError("Vehicle.Description", "Description Is Required");


            }




            if (ModelState.IsValid)
            {
                VehicleRepo.Edit(model);
                return View("Vehicles");
            }

            else
            {
                //model.Makes = from m in makeRepository.GetAll()
                //              select new SelectListItem { Text = m.MakeName, Value = m.MakeId.ToString() };

                //model.VehicleModels = from m in modelRepository.GetAll()
                //                      select new SelectListItem { Text = m.ModelName, Value = m.ModelId.ToString() };

                //model.VehicleTypes = from m in vehicleTypeRepository.GetAll()
                //                     select new SelectListItem { Text = m.VehicleTypeName, Value = m.VehicleTypeId.ToString() };

                //model.BodyStyles = from m in bodystyleRepository.GetAll()
                //                   select new SelectListItem { Text = m.BodyStyleName, Value = m.BodyStyleId.ToString() };

                //model.Transmissions = from m in transmissionRepository.GetAll()
                //                      select new SelectListItem { Text = m.TransmissionName, Value = m.TransmissionId.ToString() };

                //model.Colors = from m in colorRepository.GetAll()
                //               select new SelectListItem { Text = m.ColorName, Value = m.ColorId.ToString() };

                //model.Interiors = from m in interiorRepository.GetAll()                
                //                  select new SelectListItem { Text = m.InteriorName, Value = m.InteriorId.ToString() };

                //reload make names

                Vehicle vehicleToEdit = VehicleRepo.GetVehicleById(id);


                //model.Vehicle = new Vehicle();
                model.Vehicle = vehicleToEdit; // is the Vehcile found have a null make here
                model.Vehicle.VehicleId = vehicleToEdit.VehicleId;

                //set the the EditViewModels selection ids to match vehicleToEdit
                // why is vehicle id zero when it is passed to post contoller????

                model.Vehicle.Make = new Make();
                model.Vehicle.Make = vehicleToEdit.Make;
                model.selectedMakeName = model.Vehicle.MakeName;

                model.Vehicle.VehicleModel = new Model();
                model.Vehicle.VehicleModel = vehicleToEdit.VehicleModel;
                model.selectedModelName = model.Vehicle.VehicleModelName;

                model.Vehicle.Type = new VehicleType();
                model.Vehicle.Type = vehicleToEdit.Type;
                model.selectedVehicleTypeName = model.Vehicle.VehicleTypeName;


                model.Vehicle.BodyStyle = new BodyStyle();
                model.Vehicle.BodyStyle = vehicleToEdit.BodyStyle;
                model.selectedBodyStyleName = model.Vehicle.BodyStyleName;

                model.Vehicle.Year = vehicleToEdit.Year;

                model.Vehicle.Transmission = new Transmission();
                model.Vehicle.Transmission = vehicleToEdit.Transmission;
                model.selectedTransmissionName = model.Vehicle.TransmissionName;

                model.Vehicle.Color = new Color();
                model.Vehicle.Color = vehicleToEdit.Color;
                model.selectedColorName = model.Vehicle.ColorName;

                model.Vehicle.Interior = new Interior();
                model.Vehicle.Interior = vehicleToEdit.Interior;
                model.selectedInteriorName = model.Vehicle.InteriorName;

                model.Vehicle.Mileage = vehicleToEdit.Mileage;

                model.Vehicle.VIN = vehicleToEdit.VIN;

                model.Vehicle.MRSP = vehicleToEdit.MRSP;

                model.Vehicle.SalePrice = vehicleToEdit.SalePrice;

                model.Vehicle.Description = vehicleToEdit.Description;

                model.Vehicle.IsFeatured = vehicleToEdit.IsFeatured;

                return View("EditVehicle", model);



            }


        }

        [HttpGet]
        public ActionResult DeleteVehicle(int id)
        {
            IVehicleRepository VehicleRepo = VehicleRepositoryFactory.Create();


            VehicleRepo.Delete(id);


            return View("Vehicles");
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

            if (string.IsNullOrEmpty(model.special.Title))
            {

                ModelState.AddModelError("special.Title", "title is required");

            }

            if (string.IsNullOrEmpty(model.special.Description))
            {

                ModelState.AddModelError("special.Description", "please add a description");

            }

            if (ModelState.IsValid)
            {

                ISpecialRepository SpecialRepo = SpecialRepositoryFactory.Create();
                SpecialRepo.Add(model);
                model.specials = SpecialRepo.GetAll().ToList();
                return View("AddSpecial", model);
            }


            else
            {
                return View("AddSpecial", model);

            }
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



