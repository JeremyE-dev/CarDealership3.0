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
            //add makename to model
            model.MakeName = model.Make.MakeName;
            model.VehicleModel = repository.Models.FirstOrDefault(m => m.ModelId == viewmodel.SelectedVehicleModelId);
            //add modelname to model
            model.VehicleModelName = model.VehicleModel.ModelName; 
            model.Type = repository.VehicleTypes.FirstOrDefault(m => m.VehicleTypeId == viewmodel.SelectedVehicleTypeId);
            //add type name to model
            model.VehicleTypeName = model.Type.VehicleTypeName;
            model.BodyStyle = repository.BodyStyles.FirstOrDefault(m => m.BodyStyleId == viewmodel.SelectedBodyStyleId);
            //add bodystyle name to model
            model.BodyStyleName = model.BodyStyle.BodyStyleName;
            
            model.Year = viewmodel.Vehicle.Year;
            model.Transmission = repository.Transmissions.FirstOrDefault(m => m.TransmissionId == viewmodel.SelectedTransmissionId);
            //add transmission name
            model.TransmissionName = model.Transmission.TransmissionName;

            model.Color = repository.Colors.FirstOrDefault(m => m.ColorId == viewmodel.SelectedColorId);
            //add color name
            model.ColorName = model.Color.ColorName;
            model.Interior = repository.Interiors.FirstOrDefault(m => m.InteriorId == viewmodel.SelectedInteriorId);
            //add interior name
            model.InteriorName = model.Interior.InteriorName;
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

        public IEnumerable<Vehicle> SearchVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            //var query = from invite in db.invites
            //            where invite.Division.Contains(userInput.Division.Text) &&
            //                  invite.Status.Contains(userInput.Status.Text)
            //            select invite;

            int number;

            if (int.TryParse(searchTerm, out number))
            {

            }

            else
            {
                number = 0;
            }
              



            var repository = new CarDealership2DbContext();

            var query = from vehicle in repository.Vehicles
                        where vehicle.VehicleModelName.Contains(searchTerm) &&
                              vehicle.MakeName.Contains(searchTerm) &&
                              vehicle.Year == number      
                        select vehicle;

            //IEnumerable<Vehicle> vehicles = Enumerable.Range(minPrice, maxPrice).Select(v => v.);

            //IEnumerable<int> squares = Enumerable.Range(1, 10).Select(x => x * x);

            //foreach (int num in squares)
            //{
            //    Console.WriteLine(num);
            //}

            //var result1 = repository.Vehicles.FirstOrDefault(v => v.VehicleModelName.Contains(searchTerm));
            //      var result2 = repository.Vehicles.FirstOrDefault(v => v.MakeName.Contains(searchTerm));

            //need in parse



            //var result3 = repository.Vehicles.FirstOrDefault(v => v.Year == searchTerm);
            //var v = from vehicle in repository.Vehicles
            //        select vehicle;



            return query;
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