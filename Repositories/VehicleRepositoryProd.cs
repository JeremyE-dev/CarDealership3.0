using CarDealership2.Factories;
using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class VehicleRepositoryProd : IVehicleRepository
    {
        
        

        
        
        public void Add(AddVehicleVM viewmodel)
        {
            CarDealership2DbContext repository = new CarDealership2DbContext();

            Vehicle model = new Vehicle();

            if (!repository.Vehicles.Any())
            {
                model.VehicleId = 1;
            }

            else
            {
                model.VehicleId = repository.Vehicles.Max(m => m.VehicleId) + 1;
            }

        
            model.Make = repository.Makes.FirstOrDefault(m => m.MakeId == viewmodel.SelectedMakeId);
            model.VehicleModel = repository.Models.FirstOrDefault(m => m.ModelId == viewmodel.SelectedVehicleModelId);
            model.Type = repository.VehicleTypes.FirstOrDefault(m => m.VehicleTypeId == viewmodel.SelectedVehicleTypeId);
            model.BodyStyle = repository.BodyStyles.FirstOrDefault(m => m.BodyStyleId == viewmodel.SelectedBodyStyleId);
            model.Year = viewmodel.Vehicle.Year;
            model.Transmission = repository.Transmissions.FirstOrDefault(m => m.TransmissionId == viewmodel.SelectedTransmissionId);
            model.Color = repository.Colors.FirstOrDefault(m => m.ColorId == viewmodel.SelectedColorId);
            model.Interior = repository.Interiors.FirstOrDefault(m => m.InteriorId == viewmodel.SelectedInteriorId);
            model.Mileage = viewmodel.Vehicle.Mileage;
            model.VIN = viewmodel.Vehicle.VIN;
            model.MRSP = viewmodel.Vehicle.MRSP;
            model.SalePrice = viewmodel.Vehicle.SalePrice;
            model.Description = viewmodel.Vehicle.Description;
            
            //add picture functionality later

            repository.Vehicles.Add(model);
            repository.SaveChanges();


        }

        public void Edit(EditVehicleVM viewmodel)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            var repository = new CarDealership2DbContext();

            var vehicleToDelete = repository.Vehicles.FirstOrDefault(v => v.VehicleId == id);

            repository.Vehicles.Remove(vehicleToDelete);
            repository.SaveChanges();

        }

        public IEnumerable<Vehicle> GetAll()
        {
            var repository = new CarDealership2DbContext();

            var v = from vehicle in repository.Vehicles
                    select vehicle;

            return v;
        }
    }
}