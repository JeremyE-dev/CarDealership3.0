﻿using CarDealership2.Factories;
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

            //



            //model.MakeId = Convert.ToInt32(viewmodel.SelectedMakeId);

            int convertedMakeId = Convert.ToInt32(viewmodel.SelectedMakeId);
            int convertedModelId = Convert.ToInt32(viewmodel.SelectedVehicleModelId);
            int convertedTypeId = Convert.ToInt32(viewmodel.SelectedVehicleTypeId);
            int convertedBodyStyleId = Convert.ToInt32(viewmodel.SelectedBodyStyleId);
            int convertedTransmissionId = Convert.ToInt32(viewmodel.SelectedTransmissionId);
            int convertedColorId = Convert.ToInt32(viewmodel.SelectedColorId);
            int convertedInteriorId = Convert.ToInt32(viewmodel.SelectedInteriorId);







            model.Make = repository.Makes.FirstOrDefault(m => m.MakeId == convertedMakeId);
            //add makename to model
            model.MakeName = model.Make.MakeName;
            model.VehicleModel = repository.Models.FirstOrDefault(m => m.ModelId == convertedModelId);
            //add modelname to model
            model.VehicleModelName = model.VehicleModel.ModelName; 
            model.Type = repository.VehicleTypes.FirstOrDefault(m => m.VehicleTypeId == convertedTypeId);
            //add type name to model
            model.VehicleTypeName = model.Type.VehicleTypeName;
            model.BodyStyle = repository.BodyStyles.FirstOrDefault(m => m.BodyStyleId == convertedBodyStyleId);
            //add bodystyle name to model
            model.BodyStyleName = model.BodyStyle.BodyStyleName;
            
            model.Year = viewmodel.Vehicle.Year;
            model.Transmission = repository.Transmissions.FirstOrDefault(m => m.TransmissionId == convertedTransmissionId);
            //add transmission name
            model.TransmissionName = model.Transmission.TransmissionName;

            model.Color = repository.Colors.FirstOrDefault(m => m.ColorId == convertedColorId);
            //add color name
            model.ColorName = model.Color.ColorName;
            model.Interior = repository.Interiors.FirstOrDefault(m => m.InteriorId == convertedInteriorId);
            //add interior name
            model.InteriorName = model.Interior.InteriorName;
            model.Mileage = viewmodel.Vehicle.Mileage;
            model.VIN = viewmodel.Vehicle.VIN;
            model.MRSP = viewmodel.Vehicle.MRSP;
            model.PhotoPath = viewmodel.Vehicle.PhotoPath;
            model.SalePrice = viewmodel.Vehicle.SalePrice;
            model.Description = viewmodel.Vehicle.Description;
            
            //add picture functionality later

            repository.Vehicles.Add(model);
            repository.SaveChanges();


        }

        public void Edit(EditVehicleVM viewmodel)
        {
            var repository = new CarDealership2DbContext();

            var vehicleToEdit = repository.Vehicles.FirstOrDefault(v => v.VehicleId == viewmodel.Vehicle.VehicleId);
            //if the element is null keep it the same, else change it

            //start here to update names
            //next finish delete fubnction
            //in seed method turn off cascade deletes

            int convertedMakeId = Convert.ToInt32(viewmodel.SelectedMakeId);
            int convertedModelId = Convert.ToInt32(viewmodel.SelectedVehicleModelId);
            int convertedTypeId = Convert.ToInt32(viewmodel.SelectedVehicleTypeId);
            int convertedBodyStyleId = Convert.ToInt32(viewmodel.SelectedBodyStyleId);
            int convertedTransmissionId = Convert.ToInt32(viewmodel.SelectedTransmissionId);
            int convertedColorId = Convert.ToInt32(viewmodel.SelectedColorId);
            int convertedInteriorId = Convert.ToInt32(viewmodel.SelectedInteriorId);

            vehicleToEdit.Make = new Make();
            
            vehicleToEdit.Make = repository.Makes.FirstOrDefault(m => m.MakeId == convertedMakeId);
            //update makename - so it appears in vehicles db table
            vehicleToEdit.MakeName = vehicleToEdit.Make.MakeName;

            vehicleToEdit.VehicleModel = repository.Models.FirstOrDefault(m => m.ModelId == convertedModelId);
            vehicleToEdit.VehicleModelName = vehicleToEdit.VehicleModel.ModelName;

            vehicleToEdit.Type = repository.VehicleTypes.FirstOrDefault(m => m.VehicleTypeId == convertedTypeId);
            vehicleToEdit.VehicleTypeName = vehicleToEdit.Type.VehicleTypeName;

            vehicleToEdit.BodyStyle = repository.BodyStyles.FirstOrDefault(m => m.BodyStyleId == convertedBodyStyleId);
            vehicleToEdit.BodyStyleName = vehicleToEdit.BodyStyle.BodyStyleName;

            vehicleToEdit.Year = viewmodel.Vehicle.Year;
            
            vehicleToEdit.Transmission = repository.Transmissions.FirstOrDefault(m => m.TransmissionId == convertedTransmissionId);
            vehicleToEdit.TransmissionName = vehicleToEdit.Transmission.TransmissionName;

            vehicleToEdit.Color = repository.Colors.FirstOrDefault(m => m.ColorId == convertedColorId);
            vehicleToEdit.ColorName = vehicleToEdit.Color.ColorName;

            vehicleToEdit.Interior = repository.Interiors.FirstOrDefault(m => m.InteriorId == convertedInteriorId);
            vehicleToEdit.InteriorName = vehicleToEdit.Interior.InteriorName;

            vehicleToEdit.Mileage = viewmodel.Vehicle.Mileage;
            vehicleToEdit.VIN = viewmodel.Vehicle.VIN;
            vehicleToEdit.MRSP = viewmodel.Vehicle.MRSP;
            vehicleToEdit.SalePrice = viewmodel.Vehicle.SalePrice;
            vehicleToEdit.Description = viewmodel.Vehicle.Description;
            vehicleToEdit.IsFeatured = viewmodel.Vehicle.IsFeatured;

            if (viewmodel.UploadedFile != null)
            {
                vehicleToEdit.PhotoPath = viewmodel.Vehicle.PhotoPath;
            }
                
          

            repository.SaveChanges();

        }

        public Vehicle GetVehicleById(int id)
        {
            var repository = new CarDealership2DbContext();

            var vehicleToEdit = repository.Vehicles.FirstOrDefault(v => v.VehicleId == id);


            return vehicleToEdit;
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

            int priceRange1 = 0;
            int priceRange2 = 0;

            int yearRange1 = 0;
            int yearRange2 = 0;

         
            List<Vehicle> selectedVehicles = new List<Vehicle>();

            var repository =new CarDealership2DbContext();

            var AllVehicles = from vehicle in repository.Vehicles
                              select vehicle;

            if(minPrice == 0 && maxPrice == 0)
            {
                priceRange1 = 0;
                priceRange2 = 30000;
            }

            else if (minPrice != 0 && maxPrice == 0)
            {
                priceRange1 = minPrice;
                priceRange2 = 30000;
            }

            else if (minPrice == 0 && maxPrice != 0)
            {
                priceRange1 = minPrice;
                priceRange2 = maxPrice;
            }

            else if (minPrice != 0 && maxPrice != 0)
            {
                priceRange1 = minPrice;
                priceRange2 = maxPrice;
            }

            // begin year logic

            if (minYear == 0 && maxYear == 0)
            {
                yearRange1 = 0;
                yearRange2 = 2025;
            }

            else if (minYear != 0 && maxYear == 0)
            {
                yearRange1 = minYear;
                yearRange2 = 2025;
            }

            else if (minYear == 0 && maxYear != 0)
            {
                yearRange1 = minYear;
                yearRange2 = maxYear;
            }

            else if (minYear != 0 && maxYear != 0)
            {
                yearRange1 = minYear;
                yearRange2 = maxYear;
            }


            int number;

            //if the number is not a year, do not add anything and do not search, move to else condition

            if (int.TryParse(searchTerm, out number))
            {
                if (number > 1900 && number < 2050)
                {
                    // if condition is true, then then the number is a valid year year
                    var searchByYear = from vehicle in AllVehicles
                                       where vehicle.Year.Equals(number)
                                       select vehicle;


                    if (searchByYear.Any())
                    {
                          
                        foreach(Vehicle v in searchByYear)
                        {
                            //if price range is empty and year range is not
                            //if year range is empty and price range is not
                            
                            //if both are empty add the vehicle is it has right year
                            if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                            {
                                 selectedVehicles.Add(v);
                                
                            }

                            //if both are not empty, if eitherfield is in range add it to the list
                            if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                            {
                                if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }

                            //if prices are empty and years are not just check year
                            if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                            {
                                if (v.Year >= yearRange1 && v.Year <= yearRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }

                            // if price rannge is not empty and year range is just check price
                            if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                            {
                                if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }

                                                          
                        }
                    }

                }
            }

            else
            {
                var searchByMake = from vehicle in AllVehicles
                                   where vehicle.Make.MakeName.Contains(searchTerm)
                                   select vehicle;
                var searchByModel = from vehicle in AllVehicles
                                    where vehicle.VehicleModel.ModelName.Contains(searchTerm)
                                    select vehicle;


                if (searchByMake.Any())
                {
                    foreach (Vehicle v in searchByMake)
                    {
                   
                        if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                        {
                            selectedVehicles.Add(v);

                        }

                        //if both are not empty, if eitherfield is in range add it to the list
                        if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        //if prices are empty and years are not just check year
                        if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                        {
                            if (v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        // if price rannge is not empty and year range is just check price
                        if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }


                    }
                }

                else if (searchByModel.Any())
                {
                    foreach (Vehicle v in searchByModel)
                    {
                      

                        if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                        {
                            selectedVehicles.Add(v);

                        }

                        //if both are not empty, if eitherfield is in range add it to the list
                        if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        //if prices are empty and years are not just check year
                        if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                        {
                            if (v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        // if price rannge is not empty and year range is just check price
                        if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                    }
                }    

            }


            //if search term is empty
            if(searchTerm.Equals("0"))
            {
                foreach(Vehicle v in repository.Vehicles)
                {

                    if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                    {
                        selectedVehicles.Add(v);

                    }

                    //if both are not empty, if eitherfield is in range add it to the list
                    if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                    {
                        if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                        {
                            selectedVehicles.Add(v);
                        }
                    }

                    //if prices are empty and years are not just check year
                    if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                    {
                        if (v.Year >= yearRange1 && v.Year <= yearRange2)
                        {
                            selectedVehicles.Add(v);
                        }
                    }

                    // if price rannge is not empty and year range is just check price
                    if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                    {
                        if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                        {
                            selectedVehicles.Add(v);
                        }
                    }
       


                }
            }

            return selectedVehicles;

        }

        public IEnumerable<Vehicle> SearchNewVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {

            int priceRange1 = 0;
            int priceRange2 = 0;

            int yearRange1 = 0;
            int yearRange2 = 0;


            List<Vehicle> selectedVehicles = new List<Vehicle>();

            var repository = new CarDealership2DbContext();

            var AllVehicles = from vehicle in repository.Vehicles
                              where vehicle.Type.VehicleTypeName == "New"
                              select vehicle;

            if (minPrice == 0 && maxPrice == 0)
            {
                priceRange1 = 0;
                priceRange2 = 30000;
            }

            else if (minPrice != 0 && maxPrice == 0)
            {
                priceRange1 = minPrice;
                priceRange2 = 30000;
            }

            else if (minPrice == 0 && maxPrice != 0)
            {
                priceRange1 = minPrice;
                priceRange2 = maxPrice;
            }

            else if (minPrice != 0 && maxPrice != 0)
            {
                priceRange1 = minPrice;
                priceRange2 = maxPrice;
            }

            // begin year logic

            if (minYear == 0 && maxYear == 0)
            {
                yearRange1 = 0;
                yearRange2 = 2025;
            }

            else if (minYear != 0 && maxYear == 0)
            {
                yearRange1 = minYear;
                yearRange2 = 2025;
            }

            else if (minYear == 0 && maxYear != 0)
            {
                yearRange1 = minYear;
                yearRange2 = maxYear;
            }

            else if (minYear != 0 && maxYear != 0)
            {
                yearRange1 = minYear;
                yearRange2 = maxYear;
            }


            int number;

            //if the number is not a year, do not add anything and do not search, move to else condition

            if (int.TryParse(searchTerm, out number))
            {
                if (number > 1900 && number < 2050)
                {
                    // if condition is true, then then the number is a valid year year
                    var searchByYear = from vehicle in AllVehicles
                                       where vehicle.Year.Equals(number)
                                       select vehicle;


                    if (searchByYear.Any())
                    {

                        foreach (Vehicle v in searchByYear)
                        {
                            //if price range is empty and year range is not
                            //if year range is empty and price range is not

                            //if both are empty add the vehicle is it has right year
                            if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                            {
                                selectedVehicles.Add(v);

                            }

                            //if both are not empty, if eitherfield is in range add it to the list
                            if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                            {
                                if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }

                            //if prices are empty and years are not just check year
                            if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                            {
                                if (v.Year >= yearRange1 && v.Year <= yearRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }

                            // if price rannge is not empty and year range is just check price
                            if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                            {
                                if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }


                        }
                    }

                }
            }

            else
            {
                var searchByMake = from vehicle in AllVehicles
                                   where vehicle.Make.MakeName.Contains(searchTerm)
                                   select vehicle;
                var searchByModel = from vehicle in AllVehicles
                                    where vehicle.VehicleModel.ModelName.Contains(searchTerm)
                                    select vehicle;


                if (searchByMake.Any())
                {
                    foreach (Vehicle v in searchByMake)
                    {

                        if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                        {
                            selectedVehicles.Add(v);

                        }

                        //if both are not empty, if eitherfield is in range add it to the list
                        if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        //if prices are empty and years are not just check year
                        if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                        {
                            if (v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        // if price rannge is not empty and year range is just check price
                        if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }


                    }
                }

                else if (searchByModel.Any())
                {
                    foreach (Vehicle v in searchByModel)
                    {


                        if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                        {
                            selectedVehicles.Add(v);

                        }

                        //if both are not empty, if eitherfield is in range add it to the list
                        if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        //if prices are empty and years are not just check year
                        if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                        {
                            if (v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        // if price rannge is not empty and year range is just check price
                        if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                    }
                }

            }


            //if search term is empty
            if (searchTerm.Equals("0"))
            {
                foreach (Vehicle v in repository.Vehicles)
                {

                    if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                    {
                        selectedVehicles.Add(v);

                    }

                    //if both are not empty, if eitherfield is in range add it to the list
                    if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                    {
                        if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                        {
                            selectedVehicles.Add(v);
                        }
                    }

                    //if prices are empty and years are not just check year
                    if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                    {
                        if (v.Year >= yearRange1 && v.Year <= yearRange2)
                        {
                            selectedVehicles.Add(v);
                        }
                    }

                    // if price rannge is not empty and year range is just check price
                    if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                    {
                        if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                        {
                            selectedVehicles.Add(v);
                        }
                    }



                }
            }

            return selectedVehicles;


        }

        public IEnumerable<Vehicle> SearchUsedVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            int priceRange1 = 0;
            int priceRange2 = 0;

            int yearRange1 = 0;
            int yearRange2 = 0;


            List<Vehicle> selectedVehicles = new List<Vehicle>();

            var repository = new CarDealership2DbContext();

            var AllVehicles = from vehicle in repository.Vehicles
                              where vehicle.Type.VehicleTypeName == "Used"
                              select vehicle;

            if (minPrice == 0 && maxPrice == 0)
            {
                priceRange1 = 0;
                priceRange2 = 30000;
            }

            else if (minPrice != 0 && maxPrice == 0)
            {
                priceRange1 = minPrice;
                priceRange2 = 30000;
            }

            else if (minPrice == 0 && maxPrice != 0)
            {
                priceRange1 = minPrice;
                priceRange2 = maxPrice;
            }

            else if (minPrice != 0 && maxPrice != 0)
            {
                priceRange1 = minPrice;
                priceRange2 = maxPrice;
            }

            // begin year logic

            if (minYear == 0 && maxYear == 0)
            {
                yearRange1 = 0;
                yearRange2 = 2025;
            }

            else if (minYear != 0 && maxYear == 0)
            {
                yearRange1 = minYear;
                yearRange2 = 2025;
            }

            else if (minYear == 0 && maxYear != 0)
            {
                yearRange1 = minYear;
                yearRange2 = maxYear;
            }

            else if (minYear != 0 && maxYear != 0)
            {
                yearRange1 = minYear;
                yearRange2 = maxYear;
            }


            int number;

            //if the number is not a year, do not add anything and do not search, move to else condition

            if (int.TryParse(searchTerm, out number))
            {
                if (number > 1900 && number < 2050)
                {
                    // if condition is true, then then the number is a valid year year
                    var searchByYear = from vehicle in AllVehicles
                                       where vehicle.Year.Equals(number)
                                       select vehicle;


                    if (searchByYear.Any())
                    {

                        foreach (Vehicle v in searchByYear)
                        {
                            //if price range is empty and year range is not
                            //if year range is empty and price range is not

                            //if both are empty add the vehicle is it has right year
                            if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                            {
                                selectedVehicles.Add(v);

                            }

                            //if both are not empty, if eitherfield is in range add it to the list
                            if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                            {
                                if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }

                            //if prices are empty and years are not just check year
                            if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                            {
                                if (v.Year >= yearRange1 && v.Year <= yearRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }

                            // if price rannge is not empty and year range is just check price
                            if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                            {
                                if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }


                        }
                    }

                }
            }

            else
            {
                var searchByMake = from vehicle in AllVehicles
                                   where vehicle.Make.MakeName.Contains(searchTerm)
                                   select vehicle;
                var searchByModel = from vehicle in AllVehicles
                                    where vehicle.VehicleModel.ModelName.Contains(searchTerm)
                                    select vehicle;


                if (searchByMake.Any())
                {
                    foreach (Vehicle v in searchByMake)
                    {

                        if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                        {
                            selectedVehicles.Add(v);

                        }

                        //if both are not empty, if eitherfield is in range add it to the list
                        if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        //if prices are empty and years are not just check year
                        if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                        {
                            if (v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        // if price rannge is not empty and year range is just check price
                        if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }


                    }
                }

                else if (searchByModel.Any())
                {
                    foreach (Vehicle v in searchByModel)
                    {


                        if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                        {
                            selectedVehicles.Add(v);

                        }

                        //if both are not empty, if eitherfield is in range add it to the list
                        if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        //if prices are empty and years are not just check year
                        if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                        {
                            if (v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        // if price rannge is not empty and year range is just check price
                        if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                    }
                }

            }


            //if search term is empty
            if (searchTerm.Equals("0"))
            {
                foreach (Vehicle v in repository.Vehicles)
                {

                    if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                    {
                        selectedVehicles.Add(v);

                    }

                    //if both are not empty, if eitherfield is in range add it to the list
                    if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                    {
                        if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                        {
                            selectedVehicles.Add(v);
                        }
                    }

                    //if prices are empty and years are not just check year
                    if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                    {
                        if (v.Year >= yearRange1 && v.Year <= yearRange2)
                        {
                            selectedVehicles.Add(v);
                        }
                    }

                    // if price rannge is not empty and year range is just check price
                    if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                    {
                        if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                        {
                            selectedVehicles.Add(v);
                        }
                    }



                }
            }

            return selectedVehicles;
        }

        public IEnumerable<Vehicle> SearchUnSoldVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            
                int priceRange1 = 0;
                int priceRange2 = 0;

                int yearRange1 = 0;
                int yearRange2 = 0;


                List<Vehicle> selectedVehicles = new List<Vehicle>();

                var repository = new CarDealership2DbContext();

                var AllVehicles = from vehicle in repository.Vehicles
                                  where vehicle.IsPurchased == false
                                  select vehicle;

                if (minPrice == 0 && maxPrice == 0)
                {
                    priceRange1 = 0;
                    priceRange2 = 30000;
                }

                else if (minPrice != 0 && maxPrice == 0)
                {
                    priceRange1 = minPrice;
                    priceRange2 = 30000;
                }

                else if (minPrice == 0 && maxPrice != 0)
                {
                    priceRange1 = minPrice;
                    priceRange2 = maxPrice;
                }

                else if (minPrice != 0 && maxPrice != 0)
                {
                    priceRange1 = minPrice;
                    priceRange2 = maxPrice;
                }

                // begin year logic

                if (minYear == 0 && maxYear == 0)
                {
                    yearRange1 = 0;
                    yearRange2 = 2025;
                }

                else if (minYear != 0 && maxYear == 0)
                {
                    yearRange1 = minYear;
                    yearRange2 = 2025;
                }

                else if (minYear == 0 && maxYear != 0)
                {
                    yearRange1 = minYear;
                    yearRange2 = maxYear;
                }

                else if (minYear != 0 && maxYear != 0)
                {
                    yearRange1 = minYear;
                    yearRange2 = maxYear;
                }


                int number;

                //if the number is not a year, do not add anything and do not search, move to else condition

                if (int.TryParse(searchTerm, out number))
                {
                    if (number > 1900 && number < 2050)
                    {
                        // if condition is true, then then the number is a valid year year
                        var searchByYear = from vehicle in AllVehicles
                                           where vehicle.Year.Equals(number)
                                           select vehicle;


                        if (searchByYear.Any())
                        {

                            foreach (Vehicle v in searchByYear)
                            {
                                //if price range is empty and year range is not
                                //if year range is empty and price range is not

                                //if both are empty add the vehicle is it has right year
                                if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                                {
                                    selectedVehicles.Add(v);

                                }

                                //if both are not empty, if eitherfield is in range add it to the list
                                if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                                {
                                    if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                                    {
                                        selectedVehicles.Add(v);
                                    }
                                }

                                //if prices are empty and years are not just check year
                                if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                                {
                                    if (v.Year >= yearRange1 && v.Year <= yearRange2)
                                    {
                                        selectedVehicles.Add(v);
                                    }
                                }

                                // if price rannge is not empty and year range is just check price
                                if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                                {
                                    if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                                    {
                                        selectedVehicles.Add(v);
                                    }
                                }


                            }
                        }

                    }
                }

                else
                {
                    var searchByMake = from vehicle in AllVehicles
                                       where vehicle.Make.MakeName.Contains(searchTerm)
                                       select vehicle;
                    var searchByModel = from vehicle in AllVehicles
                                        where vehicle.VehicleModel.ModelName.Contains(searchTerm)
                                        select vehicle;


                    if (searchByMake.Any())
                    {
                        foreach (Vehicle v in searchByMake)
                        {

                            if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                            {
                                selectedVehicles.Add(v);

                            }

                            //if both are not empty, if eitherfield is in range add it to the list
                            if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                            {
                                if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }

                            //if prices are empty and years are not just check year
                            if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                            {
                                if (v.Year >= yearRange1 && v.Year <= yearRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }

                            // if price rannge is not empty and year range is just check price
                            if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                            {
                                if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }


                        }
                    }

                    else if (searchByModel.Any())
                    {
                        foreach (Vehicle v in searchByModel)
                        {


                            if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                            {
                                selectedVehicles.Add(v);

                            }

                            //if both are not empty, if eitherfield is in range add it to the list
                            if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                            {
                                if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }

                            //if prices are empty and years are not just check year
                            if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                            {
                                if (v.Year >= yearRange1 && v.Year <= yearRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }

                            // if price rannge is not empty and year range is just check price
                            if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                            {
                                if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                                {
                                    selectedVehicles.Add(v);
                                }
                            }

                        }
                    }

                }


                //if search term is empty
                if (searchTerm.Equals("0"))
                {
                    foreach (Vehicle v in repository.Vehicles)
                    {

                        if ((minPrice == 0 && maxPrice == 0) && (minYear == 0 && maxYear == 0))
                        {
                            selectedVehicles.Add(v);

                        }

                        //if both are not empty, if eitherfield is in range add it to the list
                        if ((minPrice != 0 && maxPrice != 0) && (minYear != 0 && maxYear != 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2 || v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        //if prices are empty and years are not just check year
                        if ((minPrice == 0 && maxPrice == 0) && (minYear != 0 || maxYear != 0))
                        {
                            if (v.Year >= yearRange1 && v.Year <= yearRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }

                        // if price rannge is not empty and year range is just check price
                        if ((minPrice != 0 || maxPrice != 0) && (minYear == 0 && maxYear == 0))
                        {
                            if (v.MRSP >= priceRange1 && v.MRSP <= priceRange2)
                            {
                                selectedVehicles.Add(v);
                            }
                        }



                    }
                }

                return selectedVehicles;

   
            }
        public IEnumerable<Vehicle> GetAll()
        {
            var repository = new CarDealership2DbContext();

            var v = from vehicle in repository.Vehicles
                    
                    select vehicle;

            return v;
        }

        public IEnumerable<Vehicle> GetAllUnSoldVehicles()
        {
            var repository = new CarDealership2DbContext();

            var v = from vehicle in repository.Vehicles
                    where vehicle.IsPurchased == false
                    select vehicle;

            return v;
        }


        public IEnumerable<Vehicle> GetAllNewVehicles()
        {
            var repository = new CarDealership2DbContext();

            var v = from vehicle in repository.Vehicles
                    where vehicle.Type.VehicleTypeName == "New"
            select vehicle;

            return v;
        }

        public IEnumerable<Vehicle> GetAllUsedVehicles()
        {
            var repository = new CarDealership2DbContext();

            var v = from vehicle in repository.Vehicles
                    where vehicle.Type.VehicleTypeName == "Used"
                    select vehicle;

            return v;
        }

        public IEnumerable<Vehicle> GetAllFeaturedVehicles()
        {
            var repository = new CarDealership2DbContext();

            var v = from vehicle in repository.Vehicles
                    where vehicle.IsFeatured == true &&
                          vehicle.IsPurchased == false
                    select vehicle;

            return v;
        }
    }
}