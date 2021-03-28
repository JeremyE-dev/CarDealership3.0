using CarDealership2.Interfaces;
using CarDealership2.Models;
using CarDealership2.ViewModels;
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


        public List<Sale> SearchSales(SalesReportVM viewmodel)
        {
            List<Sale> selected = new List<Sale>();
            var repository = new CarDealership2DbContext();
            var parsedDate1 = new DateTime();
            var parsedDate2 = new DateTime();


            if (!string.IsNullOrEmpty(viewmodel.Date1))
            {
                parsedDate1 = DateTime.Parse(viewmodel.Date1);
            }

            if (!string.IsNullOrEmpty(viewmodel.Date2))
            {
                parsedDate2 = DateTime.Parse(viewmodel.Date2);

            }
            //DateTime FromDate = new DateTime();
            //DateTime ToDate = new DateTime();

            if (string.IsNullOrEmpty(viewmodel.SelectedUserId) && string.IsNullOrEmpty(viewmodel.Date1) && string.IsNullOrEmpty(viewmodel.Date2))
            {
                var group = from p in repository.Purchases
                           //select all sales
                            group p by p.salesPerson.UserName
                            into s
                            select new { UserName = s.Key, TotalSales = s.Sum(x => x.purchasePrice), Count = s.Count() };

                foreach (var g in group)
                {
                    Sale s = new Sale();
                    s.UserName = g.UserName;
                    s.TotalSales = g.TotalSales;
                    s.NumberOfSales = g.Count;

                    selected.Add(s);
                }
            }


            if (!string.IsNullOrEmpty(viewmodel.SelectedUserId) && !string.IsNullOrEmpty(viewmodel.Date1) && !string.IsNullOrEmpty(viewmodel.Date2))
            {
                var group = from p in repository.Purchases
                            where p.salesPerson.Id == viewmodel.SelectedUserId && p.purchaseDate > parsedDate1 && p.purchaseDate < parsedDate2
                            group p by p.salesPerson.UserName
                            into s
                                select new { UserName = s.Key, TotalSales = s.Sum(x => x.purchasePrice), Count = s.Count() };

                foreach (var g in group)
                {
                    Sale s = new Sale();
                    s.UserName = g.UserName;
                    s.TotalSales = g.TotalSales;
                    s.NumberOfSales = g.Count;

                    selected.Add(s);
                }
            }

            //if search is not empty and both dates are, ignore dates
            if (!string.IsNullOrEmpty(viewmodel.SelectedUserId) && string.IsNullOrEmpty(viewmodel.Date1) && string.IsNullOrEmpty(viewmodel.Date2))
            {
                var group = from p in repository.Purchases
                            where p.salesPerson.Id == viewmodel.SelectedUserId 
                            group p by p.salesPerson.UserName
                            into s
                            select new { UserName = s.Key, TotalSales = s.Sum(x => x.purchasePrice), Count = s.Count() };

                foreach (var g in group)
                {
                    Sale s = new Sale();
                    s.UserName = g.UserName;
                    s.TotalSales = g.TotalSales;
                    s.NumberOfSales = g.Count;

                    selected.Add(s);
                }
            }

            //if search term in not empty date 1 is empty, date 2 is not
            if (!string.IsNullOrEmpty(viewmodel.SelectedUserId) && string.IsNullOrEmpty(viewmodel.Date1) && !string.IsNullOrEmpty(viewmodel.Date2))
            {
                //set date 1 to earliest possible date
                parsedDate1 = DateTime.MinValue;
                
                var group = from p in repository.Purchases
                            where p.salesPerson.Id == viewmodel.SelectedUserId && p.purchaseDate > parsedDate1 && p.purchaseDate < parsedDate2
                            group p by p.salesPerson.UserName
                            into s
                            select new { UserName = s.Key, TotalSales = s.Sum(x => x.purchasePrice), Count = s.Count() };

                foreach (var g in group)
                {
                    Sale s = new Sale();
                    s.UserName = g.UserName;
                    s.TotalSales = g.TotalSales;
                    s.NumberOfSales = g.Count;

                    selected.Add(s);
                }
            }

            //if search term in not empty date 1 is not empty, date 2 is empty
            if (!string.IsNullOrEmpty(viewmodel.SelectedUserId) && string.IsNullOrEmpty(viewmodel.Date1) && string.IsNullOrEmpty(viewmodel.Date2))
            {
                //set date 1 to latest possible date
                parsedDate2 = DateTime.MaxValue;

                var group = from p in repository.Purchases
                            where p.salesPerson.Id == viewmodel.SelectedUserId && p.purchaseDate > parsedDate1 && p.purchaseDate < parsedDate2
                            group p by p.salesPerson.UserName
                            into s
                            select new { UserName = s.Key, TotalSales = s.Sum(x => x.purchasePrice), Count = s.Count() };

                foreach (var g in group)
                {
                    Sale s = new Sale();
                    s.UserName = g.UserName;
                    s.TotalSales = g.TotalSales;
                    s.NumberOfSales = g.Count;

                    selected.Add(s);
                }
            }


            return selected;

        }
    }
}