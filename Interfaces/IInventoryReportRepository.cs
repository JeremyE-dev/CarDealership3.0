using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealership2.Interfaces
{
    public interface IInventoryReportRepository
    {
        List<ReportEntry> GetAllUsed();


        List<ReportEntry> GetAllNew();
      
    }
}
