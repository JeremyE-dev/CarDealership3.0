using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class PurchaseRepositoryQA : IPurchaseRepository
    {
        public static List<Purchase> purchases;

        public PurchaseRepositoryQA()
        {
            purchases = new List<Purchase>();
        }




        public void Add(PurchaseVM viewmodel)
        {

            string username = viewmodel.salesPerson.UserName;


            List<UserData> users = UserRepositoryQA.users;
            List<Vehicle> vehicles = vehicles = VehicleRepositoryQA.vehicles;

            Purchase purchase = new Purchase();

            if (!purchases.Any())
            {
                purchase.PurchaseId = 1;
            }

            else
            {
                purchase.PurchaseId = purchases.Max(m => m.PurchaseId) + 1;
            }
            //if this is teh first one set id this way:
            //if it is not the first one, set it this way:

            purchase.purchasedVehicle = viewmodel.vehicle;

            //Notes - neeed to create in memeory vehicle reposotory

            //public List<Vehicle> vehicles = VehicleRepositoryQA.vehicles;

            purchase.purchasedVehicle = vehicles.FirstOrDefault(v => v.VehicleId == viewmodel.vehicle.VehicleId);
            //find that vehicle and set is purchased to true
            var vehicleToEdit = vehicles.FirstOrDefault(v => v.VehicleId == purchase.purchasedVehicle.VehicleId);
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

                var user = users.FirstOrDefault(u => u.UserName == username);

            purchase.salesPersonUserName = user.UserName;

                purchases.Add(purchase);

        }
            
    }
}