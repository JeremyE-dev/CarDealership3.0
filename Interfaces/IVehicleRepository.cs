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

        void Add(AddVehicleVM viewmodel);

        void Edit(EditVehicleVM viewmodel);

        //void Delete(DeleteVehicleVM viewModel);

    }
}
