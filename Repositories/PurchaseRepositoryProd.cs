using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class PurchaseRepositoryProd: IPurchaseRepository
    {
        public void Add(PurchaseVM viewmodel)
        {
            CarDealership2DbContext repository = new CarDealership2DbContext();


            Purchase purchase = new Purchase();

            if (!repository.Purchases.Any())
            {
                purchase.PurchaseId = 1;
            }

            else
            {
                purchase.PurchaseId = repository.Purchases.Max(m => m.PurchaseId) + 1;
            }
            //if this is teh first one set id this way:
            //if it is not the first one, set it this way:

            purchase.purchasedVehicle = viewmodel.vehicle;
            purchase.purchasedVehicle = repository.Vehicles.FirstOrDefault(v => v.VehicleId == viewmodel.vehicle.VehicleId);
            //find that vehicle and set is purchased to true
            var vehicleToEdit = repository.Vehicles.FirstOrDefault(v => v.VehicleId == purchase.purchasedVehicle.VehicleId);
            vehicleToEdit.IsPurchased = true;

            ////just in case it is featured, set thatto false
            vehicleToEdit.IsFeatured = false;


            purchase.name = viewmodel.name;
            purchase.phone = viewmodel.phone;
            purchase.email = viewmodel.email;
            purchase.street1 = viewmodel.street1;
            purchase.street2 = viewmodel.street2;
            purchase.city = viewmodel.city;
            purchase.zipcode = viewmodel.zipcode;
            purchase.purchasePrice = viewmodel.purchasePrice;
            purchase.purchaseState = viewmodel.purchaseState;

            //todays date
            purchase.purchaseDate = DateTime.Today;

            



            //currently logged in user - do this in constructor

            //gpto users table and get this userby id

            purchase.salesPerson = repository.Users.FirstOrDefault(u => u.UserName == viewmodel.username);

            
            

            repository.Purchases.Add(purchase);

            repository.SaveChanges();

            //GETTING ENTITY VALIDATION ERROR, LIKELY DUE TO NULL VALES THAT WILL RESOLVE WITH FORM VALIDATION
            //STATUS- SKIP FOR NOW

        }
    }
}