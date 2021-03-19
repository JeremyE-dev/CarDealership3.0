using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership2.Interfaces
{
    public interface IVehicleRepository
    {
        IEnumerable<Vehicle> GetAll();

        IEnumerable<Vehicle> GetAllNewVehicles();
        IEnumerable<Vehicle> GetAllUsedVehicles();


        IEnumerable<Vehicle> SearchVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear);

        IEnumerable<Vehicle> SearchNewVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear);

        IEnumerable<Vehicle> SearchUsedVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear);



        void Add(AddVehicleVM viewmodel);

        Vehicle GetVehicleById(int id);

        void Edit(EditVehicleVM viewmodel);

        void Delete(int id);

       

    }
}
