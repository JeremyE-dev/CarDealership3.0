using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.ViewModels
{
    public class InventoryReportVM
    {
        public List<ReportEntry> usedVehiclesList = new List<ReportEntry>();

        public List<ReportEntry> newVehiclesList = new List<ReportEntry>();
    }
}