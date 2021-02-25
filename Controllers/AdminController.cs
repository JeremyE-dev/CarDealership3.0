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
using System.Web.Mvc;

namespace CarDealership2.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {

        //private UserManager<AppUser> _userManager = UserManager<ApplicationUserManager>;

        // GET: Admin
        //Note: in memory repo, add one vehicle, static list not allowing to add multiple items
        //fix later if required

        //private readonly RoleManager<IdentityRole> roleManager;

        ////private readonly UserManager<AppUser> userManager;

        //public AdminController(RoleManager<IdentityRole> roleManager)
        //{
        //    this.roleManager = roleManager;


        //}

        [HttpGet]
        public ActionResult Makes()
        {
            //this should list the makes that exist
            var model = new AddMakeVM();
            //add list to model
            //get email address
            model.makes = MakeRepositoryFactory.Create().GetAll().ToList();
            //pass user name to the model and

            //model.currentUsername = User.Identity.GetUserName();


            //give the view a list of makes to display
            return View(model);
        }


        [HttpPost]
        public ActionResult Makes(AddMakeVM model)
        {
            //here model has currect list
            //create new instance of make repository
            //this needs to 
            IMakeRepository MakeRepo = MakeRepositoryFactory.Create();



            // model.makes = MakeRepositoryFactory.Create().GetAll().ToList();

            if (string.IsNullOrEmpty(model.make.MakeName))
            {

                ModelState.AddModelError("make.MakeName", "Please Enter a Make Name");
                //return RedirectToAction("Makes");
                //model.makes = MakeRepository.GetAll().ToList();

                //
            }
            //note: success writing to db, not displaying view only displaying after second save
            // set breakpoints: either controller iss or view

            if (ModelState.IsValid)
            {
                //add to list
                //model.Add(model.make.MakeName);
                //update list
                model.makes = MakeRepo.GetAll().ToList();

                model.currentUsername = User.Identity.GetUserName();

                MakeRepositoryFactory.Create().Add(model.make.MakeName, model.currentUsername);
                //add method will add the MakeName, Make Id, Date Added
                //user will be added later - when I build that 
                //return View("Makes", model);
                return RedirectToAction("Makes", model);
            }

            else
            {
                //var makeList = MakeRepository.GetAll().ToList();
                //return View("Makes");
                //model.makes = MakeRepositoryFactory.Create().GetAll().ToList();
                model.makes = MakeRepo.GetAll().ToList();
                return View("Makes", model);
            }
        }

        //[HttpGet]

        //public ActionResult Test ()
        //{
        //    var model = new AddModelVM();
        //    //how does the data get from a text box to  the rerurned model

        //    return View(model);

        //}

        //[HttpPost]
        //public ActionResult Test(AddModelVM model)
        //{
        //    string s = model.vehicleModel.ModelName;

        //    return View(model);

        //}

        [HttpGet]
        public ActionResult Models()
        {
            //creates addvmmodel
            var model = new AddModelVM();
            //new instance of repo
            //needed to populated model list
            //var modelRepository = ModelRepositoryFactory.Create();

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

                //model.MakeId = model.SelectedMakeId;

                //change over to model

                //chamge this to take a viewmodel 
                //MakeRepositoryFactory.Create().Add(model.make.MakeName, model.currentUsername);

                //-- change create.add to take in a view model --
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

        //[HttpGet]
        //public ActionResult Users()
        //{
        //    return View();
        //}

        [HttpGet]
        public ActionResult Users()
        {
            //var userManager = Request.GetOwinContext().GetUserManager<AppUser>();

            //var roles = userManager.GetRoles(User.Identity.GetUserId());

            //ApplicationUserManager userManager = 
            //var appUserManager = new ApplicationUserManager(AppUser);
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

                RoleRepositoryProd RoleRepo = new RoleRepositoryProd();
                
                AddUserVM model = new AddUserVM();

                var context = new CarDealership2DbContext();

                var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

                var roles = roleMgr.Roles;

                model.Roles = from m in RoleRepo.GetAll()
                                select new SelectListItem { Text = m.Name, Value = m.Id.ToString() };

                return View(model);
            }

            [HttpPost]
            public async Task<ActionResult> AddUser(AddUserVM model)
            {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();

            //got the 
            var context = new CarDealership2DbContext();

            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            var roles = roleMgr.Roles;

            //populate select list


            var user = new AppUser
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                UserName = model.Email
            };

            await userManager.CreateAsync(user, model.Password);

            return View(model);


            //var signInManager = new SignInManager<AppUser>(new UserStore<AppUser>(context));



            //now get an identity user of the type I extended

            //if (ModelState.IsValid)
            //{
            //    //add role to field in userVM for easier access
            //    var user = new AppUser
            //    {
            //        FirstName = model.FirstName,
            //        LastName = model.LastName,
            //        Email = model.Email,
            //        UserName = model.Email
            //    };

            //var result = await userManager.CreateAsync(user, model.Password);

            //    //if (result.Succeeded) { }

            //}
  
            }




        [HttpPost]
            public ActionResult AddUser(AddUserDataVM model)
            {
                return View();
            }

            //public ActionResult EditUser()
            //{
            //    return View();
            //}


        }
    }



