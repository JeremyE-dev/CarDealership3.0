using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class SalesReportRepositoryQA : ISalesReportRepository
    {
        public List<Sale> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Sale> SearchSales(SalesReportVM viewmodel)
        {
            throw new NotImplementedException();
        }
    }
}