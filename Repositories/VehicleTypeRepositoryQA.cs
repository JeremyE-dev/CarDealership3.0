using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class VehicleTypeRepositoryQA : IVehicleTypeRepository
    {
        public IEnumerable<VehicleType> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}