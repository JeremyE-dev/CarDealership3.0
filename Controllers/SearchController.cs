using CarDealership2.Factories;
using CarDealership2.Interfaces;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace CarDealership2.Controllers
{
    public class SearchController : ApiController
    {
        // GET: Search

        [System.Web.Http.AcceptVerbs("GET")]
        public IHttpActionResult Get()
        {
            
            IVehicleRepository vehicleRepository = VehicleRepositoryFactory.Create();
            VehicleSearchVM model = new VehicleSearchVM();
            model.vehicles = vehicleRepository.GetAll().ToList();

        

            return Ok();
           

            //if (model.vehicles == null)
            //{
            //    return Ok();
            //}

            //else
            //{
            //    return Ok(model.vehicles);
            //}

        }
    }
}