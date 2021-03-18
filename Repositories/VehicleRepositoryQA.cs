using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class VehicleRepositoryQA : IVehicleRepository
    {
        public void Add(AddVehicleVM viewmodel)
        {
            throw new NotImplementedException();
        }

        public void Edit(EditVehicleVM viewmodel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAll()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> SearchVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            throw new NotImplementedException();
        }
    }
}