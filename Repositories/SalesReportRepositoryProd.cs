using CarDealership2.Interfaces;
using CarDealership2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Repositories
{
    public class SalesReportRepositoryProd : ISalesReportRepository
    {
       
        public List<Sale> GetAll()
        {
            List<Sale> salesByUser = new List<Sale>();

            var repository = new CarDealership2DbContext();

            //var purchasesBySalesPerson = from purchase in repository.Purchases
            //                             group purchase by purchase.salesPerson.LastName;
            //var salesPersonGroup = repository.Purchases.GroupBy(s => s.salesPerson.LastName);

            //var countPurchasesInGroup = from p in salesPersonGroup
            //                            orderby p.Count() descending
            //                            select p;

            var group = from p in repository.Purchases
                        group p by p.salesPerson.UserName
                      
                        into s
                        select new { UserName = s.Key, TotalSales =s.Sum(x => x.purchasePrice), Count = s.Count() };

             foreach(var g in group)
            {
                Sale s = new Sale();
                s.UserName = g.UserName;
                s.TotalSales = g.TotalSales;
                s.NumberOfSales = g.Count;

                salesByUser.Add(s);
            }

            return salesByUser;
            
        }
    }
}