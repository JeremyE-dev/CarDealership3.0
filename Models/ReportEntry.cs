using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealership2.Models
{
    public class ReportEntry
    {
        public int Year { get; set; }
        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public int Count { get; set; }

        public int StockValue { get; set; }
    }
}