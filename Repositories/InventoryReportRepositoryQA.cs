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


        List<ReportEntry> IInventoryReportRepository.GetAllUsed()
        {
            throw new NotImplementedException();
        }

        List<ReportEntry> IInventoryReportRepository.GetAllNew()
        {
            throw new NotImplementedException();
        }
    }
}