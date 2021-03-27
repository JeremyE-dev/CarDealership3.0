using CarDealership2.Factories;
using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class InventoryReportRepositoryProd : IInventoryReportRepository
    {
        public List<ReportEntry> GetAllUsed()
        {
            List<ReportEntry> report = new List<ReportEntry>();
            
            var repository = new CarDealership2DbContext();

            var v = from vehicle in repository.Vehicles
                    where vehicle.Type.VehicleTypeName == "Used"
                    group vehicle by new
                    {
                        vehicle.Year,
                        vehicle.Make.MakeName,
                        vehicle.VehicleModel.ModelName
                    } into usedVehicleGroup
                    select new { 
                    Year = usedVehicleGroup.Key.Year,
                    MakeName= usedVehicleGroup.Key.MakeName,
                    ModelName = usedVehicleGroup.Key.ModelName,
                    StockValue = usedVehicleGroup.Sum(x => x.MRSP),
                    Count = usedVehicleGroup.Count()
                    };

            foreach(var x in v)
            {
                ReportEntry r = new ReportEntry();

                r.Year = x.Year;
                r.MakeName = x.MakeName;
                r.Count = x.Count;
                r.StockValue = x.StockValue;

                report.Add(r);
            }

            return report;
        }



        public List<ReportEntry> GetAllNew()
        {

            List<ReportEntry> report = new List<ReportEntry>();

            var repository = new CarDealership2DbContext();

            var v = from vehicle in repository.Vehicles
                    where vehicle.Type.VehicleTypeName == "New"
                    group vehicle by new
                    {
                        vehicle.Year,
                        vehicle.Make.MakeName,
                        vehicle.VehicleModel.ModelName
                    } into usedVehicleGroup
                    select new
                    {
                        Year = usedVehicleGroup.Key.Year,
                        MakeName = usedVehicleGroup.Key.MakeName,
                        ModelName = usedVehicleGroup.Key.ModelName,
                        StockValue = usedVehicleGroup.Sum(x => x.MRSP),
                        Count = usedVehicleGroup.Count()
                    };

            foreach (var x in v)
            {
                ReportEntry r = new ReportEntry();

                r.Year = x.Year;
                r.MakeName = x.MakeName;
                r.Count = x.Count;
                r.StockValue = x.StockValue;

                report.Add(r);
            }

            return report;


        }
    }
}