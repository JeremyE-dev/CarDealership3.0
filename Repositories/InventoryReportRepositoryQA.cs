using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class InventoryReportRepositoryQA : IInventoryReportRepository
    {


        public List<ReportEntry> GetAllUsed()
        {
            List<ReportEntry> report = new List<ReportEntry>();

            VehicleRepositoryQA VehicleRepo = new VehicleRepositoryQA();

            List<Vehicle> vehicles = VehicleRepo.GetAll().ToList();

            var v = from vehicle in vehicles
                    where vehicle.VehicleTypeName == "Used"
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

        public List<ReportEntry> GetAllNew()
        {
            List<ReportEntry> report = new List<ReportEntry>();

            VehicleRepositoryQA VehicleRepo = new VehicleRepositoryQA();

            List<Vehicle> vehicles = VehicleRepo.GetAll().ToList();

          

            var v = from vehicle in vehicles
                    where vehicle.VehicleTypeName == "New"
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


        List<ReportEntry> IInventoryReportRepository.GetAllUsed()
        {
            List<ReportEntry> report = new List<ReportEntry>();

            List<Vehicle> vehicles = VehicleRepositoryQA.vehicles;

            var v = from vehicle in vehicles
                    where vehicle.VehicleTypeName == "Used"
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

        List<ReportEntry> IInventoryReportRepository.GetAllNew()
        {
            List<ReportEntry> report = new List<ReportEntry>();


            List<Vehicle> vehicles = VehicleRepositoryQA.vehicles;

            var v = from vehicle in vehicles
                    where vehicle.VehicleTypeName == "New"
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