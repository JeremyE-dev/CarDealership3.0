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
        public static List<Vehicle> vehicles;

        public VehicleRepositoryQA()
        {
            vehicles = new List<Vehicle>();
        }

        public void Add(AddVehicleVM viewmodel)
        {
            List<Make> makes = MakeRepositoryQA.makes;

            List<Model> models = ModelRepositoryQA.models;

            List<VehicleType> vehicleTypes = VehicleTypeRepositoryQA.vehicleTypes;

            List<BodyStyle> bodyStyles = BodyStyleRepositoryQA.bodyStyles;

            List<Transmission> transmissions = TransmissionRepositoryQA.transmissions;

            List<Color> colors = ColorRepositoryQA.colors;

            List<Interior> interiors = InteriorRepositoryQA.interiors;

            

            Vehicle model = new Vehicle();

            if (vehicles.Any())
            {
                model.VehicleId = 1;
            }

            else
            {
                model.VehicleId = vehicles.Max(m => m.VehicleId) + 1;
            }

            int convertedMakeId = Convert.ToInt32(viewmodel.SelectedMakeId);
            int convertedModelId = Convert.ToInt32(viewmodel.SelectedVehicleModelId);
            int convertedTypeId = Convert.ToInt32(viewmodel.SelectedVehicleTypeId);
            int convertedBodyStyleId = Convert.ToInt32(viewmodel.SelectedBodyStyleId);
            int convertedTransmissionId = Convert.ToInt32(viewmodel.SelectedTransmissionId);
            int convertedColorId = Convert.ToInt32(viewmodel.SelectedColorId);
            int convertedInteriorId = Convert.ToInt32(viewmodel.SelectedInteriorId);


            model.Make = makes.FirstOrDefault(m => m.MakeId == convertedMakeId);
            //add makename to model
            model.MakeName = model.Make.MakeName;
            model.VehicleModel = models.FirstOrDefault(m => m.ModelId == convertedModelId);
            //add modelname to model
            model.VehicleModelName = model.VehicleModel.ModelName;
            model.Type = vehicleTypes.FirstOrDefault(m => m.VehicleTypeId == convertedTypeId);
            //add type name to model
            model.VehicleTypeName = model.Type.VehicleTypeName;
            model.BodyStyle = bodyStyles.FirstOrDefault(m => m.BodyStyleId == convertedBodyStyleId);
            //add bodystyle name to model
            model.BodyStyleName = model.BodyStyle.BodyStyleName;

            model.Year = viewmodel.Vehicle.Year;
            model.Transmission = transmissions.FirstOrDefault(m => m.TransmissionId == convertedTransmissionId);
            //add transmission name
            model.TransmissionName = model.Transmission.TransmissionName;

            model.Color = colors.FirstOrDefault(m => m.ColorId == convertedColorId);
            //add color name
            model.ColorName = model.Color.ColorName;
            model.Interior = interiors.FirstOrDefault(m => m.InteriorId == convertedInteriorId);
            //add interior name
            model.InteriorName = model.Interior.InteriorName;
            model.Mileage = viewmodel.Vehicle.Mileage;
            model.VIN = viewmodel.Vehicle.VIN;
            model.MRSP = viewmodel.Vehicle.MRSP;
            model.PhotoPath = viewmodel.Vehicle.PhotoPath;
            model.SalePrice = viewmodel.Vehicle.SalePrice;
            model.Description = viewmodel.Vehicle.Description;

            //add picture functionality later

            vehicles.Add(model);


        }

        public void Delete(int id)
        {
           
            var vehicleToDelete = vehicles.FirstOrDefault(v => v.VehicleId == id);

            vehicles.Remove(vehicleToDelete);
            
        }

        public void Edit(EditVehicleVM viewmodel)
        {
            List<Make> makes = MakeRepositoryQA.makes;

            List<Model> models = ModelRepositoryQA.models;

            List<VehicleType> vehicleTypes = VehicleTypeRepositoryQA.vehicleTypes;

            List<BodyStyle> bodyStyles = BodyStyleRepositoryQA.bodyStyles;

            List<Transmission> transmissions = TransmissionRepositoryQA.transmissions;

            List<Color> colors = ColorRepositoryQA.colors;

            List<Interior> interiors = InteriorRepositoryQA.interiors;




            var vehicleToEdit = vehicles.FirstOrDefault(v => v.VehicleId == viewmodel.Vehicle.VehicleId);
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

            vehicleToEdit.Make = makes.FirstOrDefault(m => m.MakeId == convertedMakeId);
            //update makename - so it appears in vehicles db table
            vehicleToEdit.MakeName = vehicleToEdit.Make.MakeName;

            vehicleToEdit.VehicleModel = models.FirstOrDefault(m => m.ModelId == convertedModelId);
            vehicleToEdit.VehicleModelName = vehicleToEdit.VehicleModel.ModelName;

            vehicleToEdit.Type = vehicleTypes.FirstOrDefault(m => m.VehicleTypeId == convertedTypeId);
            vehicleToEdit.VehicleTypeName = vehicleToEdit.Type.VehicleTypeName;

            vehicleToEdit.BodyStyle = bodyStyles.FirstOrDefault(m => m.BodyStyleId == convertedBodyStyleId);
            vehicleToEdit.BodyStyleName = vehicleToEdit.BodyStyle.BodyStyleName;

            vehicleToEdit.Year = viewmodel.Vehicle.Year;

            vehicleToEdit.Transmission = transmissions.FirstOrDefault(m => m.TransmissionId == convertedTransmissionId);
            vehicleToEdit.TransmissionName = vehicleToEdit.Transmission.TransmissionName;

            vehicleToEdit.Color = colors.FirstOrDefault(m => m.ColorId == convertedColorId);
            vehicleToEdit.ColorName = vehicleToEdit.Color.ColorName;

            vehicleToEdit.Interior = interiors.FirstOrDefault(m => m.InteriorId == convertedInteriorId);
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
        }

        public IEnumerable<Vehicle> GetAll()
        {
            

            var v = from vehicle in vehicles

                    select vehicle;

            return v;
        }

        public IEnumerable<Vehicle> GetAllFeaturedVehicles()
        {
            
            var v = from vehicle in vehicles
                    where vehicle.IsFeatured == true &&
                          vehicle.IsPurchased == false
                    select vehicle;

            return v;
        }

        public IEnumerable<Vehicle> GetAllNewVehicles()
        {            
            var v = from vehicle in vehicles
                    where vehicle.Type.VehicleTypeName == "New"
                    select vehicle;

            return v;
        }

        public IEnumerable<Vehicle> GetAllUnSoldVehicles()
        {
           

            var v = from vehicle in vehicles
                    where vehicle.IsPurchased == false
                    select vehicle;

            return v;
        }

        public IEnumerable<Vehicle> GetAllUsedVehicles()
        {
            

            var v = from vehicle in vehicles
                    where vehicle.Type.VehicleTypeName == "Used"
                    select vehicle;

            return v;
        }

        public Vehicle GetVehicleById(int id)
        {
            

            var vehicleToEdit = vehicles.FirstOrDefault(v => v.VehicleId == id);


            return vehicleToEdit;
        }

        //searches all new vehicles
        public IEnumerable<Vehicle> SearchNewVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            int priceRange1 = 0;
            int priceRange2 = 0;

            int yearRange1 = 0;
            int yearRange2 = 0;


            List<Vehicle> selectedVehicles = new List<Vehicle>();

            

            var AllVehicles = from vehicle in vehicles
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
                foreach (Vehicle v in vehicles)
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

        //searches all new and used vehichles that are not purchased
        public IEnumerable<Vehicle> SearchUnSoldVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            int priceRange1 = 0;
            int priceRange2 = 0;

            int yearRange1 = 0;
            int yearRange2 = 0;


            List<Vehicle> selectedVehicles = new List<Vehicle>();
                        

            var AllVehicles = from vehicle in vehicles
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
                foreach (Vehicle v in vehicles)
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

        //searches all used vehicles
        public IEnumerable<Vehicle> SearchUsedVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {
            int priceRange1 = 0;
            int priceRange2 = 0;

            int yearRange1 = 0;
            int yearRange2 = 0;


            List<Vehicle> selectedVehicles = new List<Vehicle>();

           

            var AllVehicles = from vehicle in vehicles
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
                foreach (Vehicle v in vehicles)
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

        //searches all vehicles in database regardless of status used, new, sold not sold
        public IEnumerable<Vehicle> SearchVehicles(string searchTerm, int minPrice, int maxPrice, int minYear, int maxYear)
        {

            int priceRange1 = 0;
            int priceRange2 = 0;

            int yearRange1 = 0;
            int yearRange2 = 0;


            List<Vehicle> selectedVehicles = new List<Vehicle>();


            var AllVehicles = from vehicle in vehicles
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
                foreach (Vehicle v in vehicles)
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
    }
}