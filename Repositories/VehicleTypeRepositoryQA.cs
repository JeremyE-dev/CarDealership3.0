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

        public List<VehicleType> vehicleTypes;

        public VehicleTypeRepositoryQA()
        {
            VehicleType New = new VehicleType {VehicleTypeId = 1, VehicleTypeName = "New" };
            VehicleType Used = new VehicleType { VehicleTypeId = 1, VehicleTypeName = "Used" };

            vehicleTypes.Add(New);
            vehicleTypes.Add(Used);
        }
        public IEnumerable<VehicleType> GetAll()
        {
            var m = from model in vehicleTypes
                    select model;

            return m;
        }
    }
}