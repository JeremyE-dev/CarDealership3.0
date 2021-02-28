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

        [HttpGet]

        public ActionResult Test()
        {
            //RoleRepositoryProd RoleRepo = new RoleRepositoryProd();

            //var model = new AddUserVM();

            //model.Roles = from r in RoleRepo.GetAll()
            //              select new SelectListItem { Text = r.Name, Value = r.Id.ToString() };

            //model.Roles = from r in RoleRepo.GetAll()
            //              select new SelectListItem { Text = r.RoleName, Value = r.RoleId };

            //CarDealership2DbContext db = new CarDealership2DbContext();

            //var query = db.Roles.Select(c => new SelectListItem
            //{
            //    Value = c.Id.ToString(),
            //    Text = c.Name,
            //    Selected = c.Id.Equals(3)
            //});

            //var model = new AddUserVM 
            //{ 
            //    Roles = query.AsEnumerable() 
            //};

            //return View(model);


            ////data = id, text = namer

            ////TestModel model = new TestModel();


            //////model.Roles = new SelectList(db.Roles, "Id", "Name");

            //////ViewBag.ViewBagRoles = new SelectList(db.Roles, "Id", "Name");

            ////model.Roles = from r in db.Roles
            ////              select new SelectListItem { Text = r.Name, Value = r.Id.ToString() };

            ////create new model
            //AddUserVM model = new AddUserVM();

            //model.SelectedRole = new AppRole();

            //model.Roles = from r in db.Roles
            //              select new SelectListItem { Text = r.Name, Value = r.Id.ToString() };

            //model.rolenames = new List<string>();

            ////set names of roles 
            //foreach (AppRole x in db.Roles)
            //{
            //    model.rolenames.Add(x.Name);
            //}

            //return View(model);
            return View();


        }

        [HttpPost]
        public ActionResult Test(RoleModel model)
        {
            var selectedValue = model.SelectedRoleType;

            ViewBag.RoleType = selectedValue.ToString();

            //RoleRepositoryProd RoleRepo = new RoleRepositoryProd();
            
            //model.Roles = from r in RoleRepo.GetAll()
            //              select new SelectListItem { Text = r.RoleName, Value = r.RoleId };
            return View();

        }

        //[HttpPost]
        //public ActionResult Test(UserModel model)
        //{
        //    var selectedValue = model.SelectTeaType;
        //    ViewBag.TeaType = selectedValue.ToString();


        //    return View();

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

            //var context = new CarDealership2DbContext();

            //var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            //var roles = roleMgr.Roles;

            //model.Roles = from m in RoleRepo.GetAll()
            //              select new SelectListItem { Text = m.Name, Value = m.Id.ToString() };

            return View(model);
        }

        [HttpPost]

        //by the timr I get here, model.SelectedRoleId should have a value
        public ActionResult AddUser(AddUserVM model)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            RoleRepositoryProd RoleRepo = new RoleRepositoryProd();
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

            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("Password", "Password is Required");
            }

            if (string.IsNullOrEmpty(model.ConfirmPassword))
            {
                ModelState.AddModelError("ConfirmPassword", "Confirm Password is Required");
            }

            //got the 
            var context = new CarDealership2DbContext();

            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            var roles = roleMgr.Roles;

            //populate select list


            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email
                };

                //get the name of the rolke selected in the dropdown;

                //model.Roles = from m in RoleRepo.GetAll()
                //              select new SelectListItem { Text = m.Name, Value = m.Id.ToString() };

                //foreach (SelectListItem x in model.Roles)
                //{
                //    if (x.Selected == true)
                //    {
                //        model.SelectedRoleName = x.Text;
                //    }
                //}


                //userManager.AddPassword(user.Id, model.Password);




                UserRepo.Add(model);


            //await userManager.CreateAsync(user, model.Password);

            //not sure if this is the corerct view


            //return RedirectToAction("Models", model);
            return RedirectToAction("AddUser", model);
            }

            else //add error messages
            {
                //model.Roles = from m in RoleRepo.GetAll()
                //              select new SelectListItem { Text = m.Name, Value = m.Id.ToString() };
                //not sure if this is the corerct view
                return View("AddUser", model);
            }





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

            //

            //}

        }




        //[HttpPost]
        //    public ActionResult AddUser(AddUserDataVM model)
        //    {
        //        return View();
        //    }

        //    //public ActionResult EditUser()
        //    //{
        //    //    return View();
        //    //}


    }
    }



