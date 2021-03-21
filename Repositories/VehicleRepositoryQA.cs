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

        public void Delete(int id)
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

        public IEnumerable<Vehicle> GetAllFeaturedVehicles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAllNewVehicles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAllUnSoldVehicles()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAllUsedVehicles()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleById(int id)
        {
            throw new NotImplementedException();
        }

        //searches all new vehicles
        public IEnumerable<Vehicle> SearchNewVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            throw new NotImplementedException();
        }

        //searches all new and used vehichles that are not purchased
        public IEnumerable<Vehicle> SearchUnSoldVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            throw new NotImplementedException();
        }

        //searches all used vehicles
        public IEnumerable<Vehicle> SearchUsedVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            throw new NotImplementedException();
        }

        //searches all vehicles in database regardless of status used, new, sold not sold
        public IEnumerable<Vehicle> SearchVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            throw new NotImplementedException();
        }
    }
}